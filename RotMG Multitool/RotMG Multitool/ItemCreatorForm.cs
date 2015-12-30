using MetroFramework.Forms;
using RotMG_Multitool.Serializers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RotMG_Multitool
{
    public partial class ItemCreatorForm : MetroForm
    {
        public ItemCreatorForm()
        {
            InitializeComponent();
            itemSettingsGroupBox.Enabled = false;
            createXMLButton.Hide();
            openItemImgBtn.Hide();
            dumpResourcesBtn.Hide();
        }

        private readonly string PATH = Path.GetDirectoryName(Application.ExecutablePath);
        private string swfFile;
        private string imgFile;
        private string xml;
        private string newSpriteSheetPath;
        private string spriteSheetPath;
        private int spriteSheetFileId;
        private int hex = 0x00;
        public static bool remoteTexture = true;

        private void createXMLButton_Click(object sender, EventArgs e)
        {
            try
            {
                //3rd: Import image into a sprite sheet...
                insertImageIntoSpriteSheet();
                UpdateThings();
                xml = Item.Serialize();
                replaceImage();
                //Add files back into client, repack
                replaceFiles(spriteSheetPath, spriteSheetFileId);

                string binFile = Directory.GetFiles($"{PATH}/BinaryData").First();
                var lines = File.ReadAllText(binFile);
                lines = lines.Replace ("</Objects>", $"{xml}\n</Objects>");
                File.WriteAllText(binFile, lines);
                replaceFiles(binFile, 1);
                MessageBox.Show("Item has been created and added to client!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), caption: "Error");
            }
        }

        private void UpdateThings()
        {
            try
            {
                Item.ObjectType = objectTypeText.Text;
                Item.ObjectId = objectIdText.Text;
                Item.Class = classText.Text;
                Item.DisplayName = displayNameText.Text;
                Item.RemoteTextureInstance = rtextureInstanceText.Text;
                Item.RemoteTextureID = rtextureIdText.Text;
                Item.TextureFile = "lofiObj5";
                Item.TextureIndex = "0x" + hex.ToString("X");
                Item.SlotType = GetSlotTypeFromItem(slotTypeCombobox.Text);
                Item.Tier = int.Parse(tierText.Text);
                Item.Description = descriptionText.Text;
                Item.RateOfFire = int.Parse(rateOfFireText.Text);
                Item.BagType = GetBagTypeFromType(bagTypeCombobox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), caption: "Error");
            }
        }

        private void textureButton_Click(object sender, EventArgs e)
        {
            if (textureButton.Text == "Remote Texture")
            {
                textureButton.Text = "Texture";
                textureFileText.Show();
                textureIndexText.Show();

                rtextureIdText.Hide();
                rtextureInstanceText.Hide();
                warningLabel.Hide();

                remoteTexture = false;
            }
            else
            {
                textureButton.Text = "Remote Texture";
                rtextureIdText.Show();
                rtextureInstanceText.Show();
                warningLabel.Show();

                textureFileText.Hide();
                textureIndexText.Hide();

                remoteTexture = true;
            }
        }

        private int GetSlotTypeFromItem(string item)
        {
            switch (item)
            {
                case "Sword": return 1;
                case "Dagger": return 2;
                case "Bow": return 3;
                case "Wand": return 8;
                case "Staff": return 17;
                default: return 1;
            }
        }

        private int GetBagTypeFromType(string bagtype)
        {
            switch (bagtype)
            {
                case "Brown Bag": return 0;
                case "Purple Bag": return 1;
                case "High Tiered Bag": return 2;
                case "Potion Bag": return 3;
                case "White Bag": return 4;
                default: return 4;
            }
        }

        private void loadSwfBtn_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "SWF files|*.swf";
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                openItemImgBtn.Show();
                swfFile = ofd.FileName;
            }

            ofd.Dispose();
        }

        private void openItemImgBtn_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "PNG files|*.png";
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                Image img = Image.FromFile(ofd.FileName);
                if (img.Height == 8 && img.Width == 8)
                {
                    dumpResourcesBtn.Show();
                    imgFile = ofd.FileName;
                }
                else
                {
                    MessageBox.Show("Image must be 8px by 8px!");
                }
            }
            ofd.Dispose();
        }

        private void dumpResourcesBtn_Click(object sender, EventArgs e)
        {
            if (Directory.Exists($"{PATH}\\Images"))
            {
                Directory.Delete($"{PATH}\\Images", true);
            }

            if (Directory.Exists($"{PATH}\\BinaryData"))
            {
                Directory.Delete($"{PATH}\\BinaryData", true);
            }

            Parallel.Invoke(() =>
            {
                //1st: Extract Images...
                extractAllImages(swfFile);

                //2nd: Extract a .bin file to add the item to...
                extractAllBinFiles(swfFile);
            });
            
            itemSettingsGroupBox.Enabled = true;
            createXMLButton.Show();
        }

        private void extractAllImages(string swfFile)
        {
            runFFDecWithArguments($"-export image \"{PATH}/Images\" \"{swfFile}\"");
        }

        private void extractAllBinFiles(string swfFile)
        {
            runFFDecWithArguments($"-export binaryData \"{PATH}/BinaryData\" \"{swfFile}\"");
        }

        private void runFFDecWithArguments(string arguments)
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = $"{PATH}/FFDec/ffdec.exe",
                    Arguments = arguments,
                    UseShellExecute = true,
                    RedirectStandardOutput = false,
                    CreateNoWindow = false
                }
            };

            proc.Start();
            proc.WaitForExit();
        }

        private void insertImageIntoSpriteSheet()
        {
            /*
             *
             *       This method was hard to write, it should be hard to read...
             *
             */

            //161_kabam.rotmg.assets.EmbeddedAssets_lofiObj5Embed_.png => <File>lofiObj5</File>

            spriteSheetPath = Directory.GetFiles($"{PATH}/Images").ToList().Where(file => file.Contains("lofiObj5Embed")).First();
            spriteSheetFileId = int.Parse(Path.GetFileName(spriteSheetPath).Substring(0, 3));
            Bitmap spriteSheetImg = new Bitmap(spriteSheetPath);
            Bitmap itemImg = new Bitmap(imgFile);
            int height = spriteSheetImg.Height - 1;
            int width = spriteSheetImg.Width;

            //Find last row of image
            var divisions = (width / 8) - 1;

            var itemPixels = new List<Color>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    itemPixels.Add(itemImg.GetPixel(j, i));
                }
            }

            for (int d = 0; d < divisions * 8; d += 8)
            {
                List<Color> pixels = new List<Color>();

                for (int i = 7; i >= 0; i--)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        pixels.Add(spriteSheetImg.GetPixel(j + d, height - i));
                    }
                }

                //check if space is empty, again a awful hackish solution i've come up with
                if (pixels.Count(pixel => pixel == Color.FromArgb(0, 0, 0, 0) || pixel == Color.FromArgb(255, 255, 255, 255)) != 64)
                {
                    //if not, check the next element over
                    if (d / 8 == divisions - 1)
                    {
                        //End of last row... Add a new row.
                        var newSpriteSheet = resizeImage(spriteSheetImg);

                        for (int i = 7; i >= 0; i--)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                //probably the most hackish solution you'll ever see
                                newSpriteSheet.SetPixel(j, height + 8 - i, itemPixels.First());
                                itemPixels.RemoveAt(0);
                            }
                        }

                        hex = (width * height) / 8 / 8;
                        //((128 * 80) /8 /8) = 60th item => hex = 0xa0
                        //save sprite sheet and get the hell out of here
                        newSpriteSheetPath = spriteSheetPath.Replace(".png", "-new.png");
                        newSpriteSheet.Save(newSpriteSheetPath);
                        newSpriteSheet.Dispose();
                        spriteSheetImg.Dispose();
                        return;
                    }
                    continue;
                }

                //if it is, use it
                for (int i = 7; i >= 0; i--)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        spriteSheetImg.SetPixel(j + d, height - i, itemPixels.First());
                        itemPixels.RemoveAt(0);
                    }
                }
                hex = ((((height - 7) * width)) / 8 / 8) + (d / 8); //fuck me
                newSpriteSheetPath = spriteSheetPath.Replace(".png", "-new.png");
                spriteSheetImg.Save(newSpriteSheetPath);
                spriteSheetImg.Dispose();
                return;
            }
        }

        private Bitmap resizeImage(Bitmap imgToResize)
        {
            Bitmap bmp = new Bitmap(imgToResize.Width, imgToResize.Height + 8);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            g.DrawImageUnscaled(imgToResize, 0, 0);
            return bmp;
        }

        private void replaceImage()
        {
            File.Delete(spriteSheetPath);
            File.Move(newSpriteSheetPath, spriteSheetPath);
        }

        private void replaceFiles(string inFile, int fileId)
        {
            runFFDecWithArguments($"-replace \"{swfFile}\" \"{swfFile}\" {fileId} \"{inFile}\"");
        }
    }
}
