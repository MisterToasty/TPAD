using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace TPAD
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public Image DownloadImageFromUrl(string imageUrl)
        {
            Image image = null;

            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(imageUrl);
                webRequest.AllowWriteStreamBuffering = true;
                webRequest.Timeout = 30000;

                WebResponse webResponse = webRequest.GetResponse();

                Stream stream = webResponse.GetResponseStream();

                image = Image.FromStream(stream);

                webResponse.Close();
            }
            catch (Exception ex)
            {
                return null;
            }

            return image;
        }

        public string[] sites = new string[] { "nekos.life", "nekobot.xyz", "neko-love.xyz", "oboobs.ru", "obutts.ru" };
        public string[] nekoslifechoices = new string[] { "femdom", "tickle", "classic", "ngif", "erofeet", "meow", "erok", "poke", "les", "v3", "hololewd", "nekoapi_v3.1", "lewdk", "keta", "feetg", "nsfw_neko_gif", "eroyuri", "kiss", "8ball", "kuni", "tits", "pussy_jpg", "cum_jpg", "pussy", "lewdkemo", "lizard", "slap", "lewd", "cum", "cuddle", "spank", "smallboobs", "goose", "Random_hentai_gif", "avatar", "fox_girl", "nsfw_avatar", "hug", "gecg", "boobs", "pat", "feet", "smug", "kemonomimi", "solog", "holo", "wallpaper", "bj", "woof", "yuri", "trap", "anal", "baka", "blowjob", "holoero", "feed", "neko", "gasm", "hentai", "futanari", "ero", "solo", "waifu", "pwankg", "eron", "erokemo" };
        public string[] nekobotxyzchoices = new string[] { "hass", "hmidriff", "pgif", "4k", "hentai", "holo", "hneko", "neko", "hkitsune", "kemonomimi", "anal", "hanal", "kanna", "ass", "pussy", "thigh", "hthigh", "gah", "coffee", "food" };
        public string[] nekolovechoices = new string[] { "nekolewd", "neko", "kitsune", "hug", "pat", "waifu", "cry", "kiss" };
        public string[] oboobschoices = new string[] { "default" };
        public string[] previmg = new string[] { };

        private void MainForm_Load(object sender, EventArgs e)
        {
            siteChoice.Items.AddRange(sites);
            choices.Items.AddRange(nekoslifechoices);
            randomImage();
        }

        private string randomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new string(stringChars);
            return finalString;
        }

        public string imgurl, fileName, ext, randomName;

        //public string rootPath = @"E:\Toasty's Python Projects\TPAD\c#\TPAD\images";
        public string rootPath;

        public bool firstchoice = true;

        private void siteChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (firstchoice == true)
            {
                switch (siteChoice.Text)
                {
                    case "nekos.life":
                        choices.Items.Clear();
                        choices.Items.AddRange(nekoslifechoices);
                        choices.Text = "femdom";
                        break;

                    case "nekobot.xyz":
                        choices.Items.Clear();
                        choices.Items.AddRange(nekobotxyzchoices);
                        choices.Text = "hass";
                        break;

                    case "neko-love.xyz":
                        choices.Items.Clear();
                        choices.Items.AddRange(nekolovechoices);
                        choices.Text = "nekolewd";
                        break;

                    case "oboobs.ru":
                        choices.Items.Clear();
                        choices.Items.AddRange(oboobschoices);
                        choices.Text = "default";
                        break;

                    case "obutts.ru":
                        choices.Items.Clear();
                        choices.Items.AddRange(oboobschoices);
                        choices.Text = "default";
                        break;
                }
                Array.Clear(previmg, 0, previmg.Length);
            }
        }

        public bool mdb = false;
        public int imgnum = -1;

        public void randomImage()
        {
            WebClient client = new WebClient();
            string source = client.DownloadString("https://pastebin.com/raw/SKiMxc92");
            dynamic data = JObject.Parse(source);
            string rootPath = Directory.GetCurrentDirectory();
            switch (siteChoice.Text)
            {
                case "nekos.life":
                    //choices.Items.Clear();
                    //choices.Items.AddRange(nekoslifechoices);
                    //choices.Text = "femdom";
                    source = client.DownloadString("https://nekos.life/api/v2/img/" + choices.Text);
                    data = JObject.Parse(source);
                    imgurl = data.url;
                    break;

                case "nekobot.xyz":
                    source = client.DownloadString("https://nekobot.xyz/api/image?type=" + choices.Text);
                    data = JObject.Parse(source);
                    imgurl = data.message;
                    break;

                case "neko-love.xyz":
                    source = client.DownloadString("https://neko-love.xyz/api/v1/" + choices.Text);
                    data = JObject.Parse(source);
                    imgurl = data.url;
                    break;

                case "oboobs.ru":
                    source = client.DownloadString("http://api.oboobs.ru/boobs/0/1/random");
                    JArray jsonArray2 = JArray.Parse(source);
                    data = JObject.Parse(jsonArray2[0].ToString());
                    imgurl = "http://media.oboobs.ru/" + data.preview;
                    break;

                case "obutts.ru":
                    source = client.DownloadString("http://api.obutts.ru/butts/0/1/random");
                    JArray jsonArray3 = JArray.Parse(source);
                    data = JObject.Parse(jsonArray3[0].ToString());
                    imgurl = "http://media.obutts.ru/" + data.preview;
                    break;
            }
            ext = Path.GetExtension(imgurl);

            //Image image = DownloadImageFromUrl(imgurl.Trim());
            randomName = randomString() + ext;
            rootPath = Directory.GetCurrentDirectory();
            rootPath += "\\images\\";
            rootPath += siteChoice.Text;
            rootPath += "\\";
            rootPath += choices.Text;
            rootPath = rootPath.ToString();

            Console.WriteLine(rootPath);
            try
            {
                Directory.CreateDirectory(rootPath);
            }
            catch
            {
                return;
            }
            fileName = Path.Combine(rootPath, randomName);
            if (mdb == false)
            {
                previmg = previmg.Append(imgurl).ToArray();
                pictureBox1.ImageLocation = imgurl;
                imgnum += 1;
                Console.WriteLine(previmg[imgnum]);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            randomImage();
            Image image = DownloadImageFromUrl(imgurl.Trim());
            image.Save(fileName);
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            Image image = DownloadImageFromUrl(imgurl.Trim());
            image.Save(fileName);
        }

        private void dniButton_Click(object sender, EventArgs e)
        {
            mdb = true;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 500;
            timer1.Start();
        }

        private void smdButton_Click(object sender, EventArgs e)
        {
            mdb = false;
            timer1.Stop();
        }

        public void nextButton_Click(object sender, EventArgs e)
        {
            randomImage();
        }

        private void prevImgButton_Click(object sender, EventArgs e)
        {
            if (imgnum > 0)
            {
                imgnum -= 1;
                Console.WriteLine(previmg[imgnum]);
                pictureBox1.ImageLocation = previmg[imgnum];
            }
        }
    }
}