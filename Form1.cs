using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Collections;

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

        private static char[] prntchars = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public string[] sites = new string[] { "nekos.life", "nekobot.xyz", "neko-love.xyz", "oboobs.ru", "obutts.ru", "prnt.sc" };
        public string[] nekoslifechoices = new string[] { "femdom", "tickle", "classic", "ngif", "erofeet", "meow", "erok", "poke", "les", "v3", "hololewd", "nekoapi_v3.1", "lewdk", "keta", "feetg", "nsfw_neko_gif", "eroyuri", "kiss", "8ball", "kuni", "tits", "pussy_jpg", "cum_jpg", "pussy", "lewdkemo", "lizard", "slap", "lewd", "cum", "cuddle", "spank", "smallboobs", "goose", "Random_hentai_gif", "avatar", "fox_girl", "nsfw_avatar", "hug", "gecg", "boobs", "pat", "feet", "smug", "kemonomimi", "solog", "holo", "wallpaper", "bj", "woof", "yuri", "trap", "anal", "baka", "blowjob", "holoero", "feed", "neko", "gasm", "hentai", "futanari", "ero", "solo", "waifu", "pwankg", "eron", "erokemo" };
        public string[] nekobotxyzchoices = new string[] { "hass", "hmidriff", "pgif", "4k", "hentai", "holo", "hneko", "neko", "hkitsune", "kemonomimi", "anal", "hanal", "kanna", "ass", "pussy", "thigh", "hthigh", "gah", "coffee", "food" };
        public string[] nekolovechoices = new string[] { "nekolewd", "neko", "kitsune", "hug", "pat", "waifu", "cry", "kiss" };
        public string[] oboobschoices = new string[] { "default" };
        public string[] previmg = new string[] { };

        private string GetHash(string path)
        {
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return Encoding.UTF8.GetString(new SHA1Managed().ComputeHash(fileStream));
            }
        }

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

                    case "prnt.sc":
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
            // client.DownloadString("https://pastebin.com/raw/SKiMxc92");
            string source = client.DownloadString("https://hastebin.com/raw/ejacojoyey"); ;
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

                case "prnt.sc":
                    Random rm = new Random();

                    string url = "https://prnt.sc/"
                        + prntchars[rm.Next(0, prntchars.Length - 1)]
                        + prntchars[rm.Next(0, prntchars.Length - 1)]
                        + prntchars[rm.Next(0, prntchars.Length - 1)]

                        + prntchars[rm.Next(0, prntchars.Length - 1)]
                        + prntchars[rm.Next(0, prntchars.Length - 1)]
                        + prntchars[rm.Next(0, prntchars.Length - 1)]
                    ;
                    imgurl = Prnt_download(url);
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

        private void removeDupes_Click(object sender, EventArgs e)
        {
            rootPath = Directory.GetCurrentDirectory();
            rootPath += "\\images\\";
            rootPath += siteChoice.Text;
            rootPath += "\\";
            rootPath += choices.Text;
            rootPath = rootPath.ToString();
            Directory.GetFiles(rootPath)
            .Select(
            f => new
            {
                FileName = f,
                FileHash = GetHash(f)
            })
            .GroupBy(f => f.FileHash)
            .Select(g => new { FileHash = g.Key, Files = g.Select(z => z.FileName).ToList() })
            .SelectMany(f => f.Files.Skip(1))
            .ToList()
            .ForEach(File.Delete);
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
                pictureBox1.ImageLocation = previmg[imgnum];
            }
        }

        private static string Prnt_download(string url)
        {
            WebClient wc = new WebClient();
            wc.Headers.Add("user-agent", "TPAD.exe");

            foreach (string link in get_html_all(new Uri(url), wc.DownloadData(url)))
            {
                if (string.IsNullOrEmpty(link)) { continue; }
                if (!Uri.IsWellFormedUriString(link, UriKind.Absolute)) { continue; }
                if (!link.Contains(".png")) { continue; }
                if (link.Contains("favicon")) { continue; }
                if (link.Contains("footer-logo.png")) { continue; }
                if (link.Contains("icon")) { continue; }
                if (link.Contains("searchbyimage")) { continue; }

                return link;
            }
            return "error";
        }

        private static bool compare(Bitmap bmp1, Bitmap bmp2)
        {
            bool equals = true;
            bool flag = true;  //Inner loop isn't broken

            //Test to see if we have the same size of image
            if (bmp1.Size == bmp2.Size)
            {
                for (int x = 0; x < bmp1.Width; ++x)
                {
                    for (int y = 0; y < bmp1.Height; ++y)
                    {
                        if (bmp1.GetPixel(x, y) != bmp2.GetPixel(x, y))
                        {
                            equals = false;
                            flag = false;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        break;
                    }
                }
            }
            else
            {
                equals = false;
            }
            return equals;
        }

        private static string GetURLFilename(string url)
        {
            string[] index = url.Split('/');
            string name = index[index.Length - 1];
            return name + ".png";
        }

        private static string time()
        {
            TimeSpan diff = (new DateTime(2011, 02, 10) - new DateTime(2011, 02, 01));
            return diff.TotalMilliseconds.ToString();
        }

        private static List<string> root_urls(Uri website, List<string> urls)
        {
            List<string> items = new List<string>();

            foreach (string url in urls)
            {
                string item = HttpUtility.HtmlDecode(url);

                if (Uri.IsWellFormedUriString(item, UriKind.Absolute))
                {
                    items.Add(item);

                    continue;
                }

                if (item.StartsWith("//")) //add http or https
                {
                    items.Add(website.ToString().Split(':')[0] + ":" + item);
                    items.Add(website.ToString().Split(':')[0] + ":" + item);
                }
                else if (item.StartsWith("/")) //add website name
                {
                    if (website.ToString().EndsWith("/"))
                    {
                        items.Add(website.ToString() + item);
                    }
                    else
                    {
                        items.Add(website.ToString() + "/" + item);
                    }
                }
                else
                {
                    items.Add(item); //add junk
                }
            }

            return items;
        }

        private static List<string> get_html_all(Uri URL, byte[] html)
        {
            //GET ALL CHARS
            char[] htmlChars = System.Text.Encoding.Default.GetString(html).ToArray();

            //EXTRACT ALL STRINGS LIKE: 'asdsadas' "asdasdasd"
            List<string> html_quotes = html_get_everyobject_in_quotes(htmlChars);
            List<string> html_apostrophes = html_get_everyobject_in_apostrophes(htmlChars);

            //ADD
            List<string> non_rooted = new List<string>();
            foreach (string l in html_quotes) { non_rooted.Add(l); }
            foreach (string l in html_apostrophes) { non_rooted.Add(l); }

            /// Uri myUri = new Uri("http://www.contoso.com:8080/");
            /// string host = myUri.Host;  // host is "www.contoso.com"

            //ROOT
            List<string> html_all = root_urls(URL, non_rooted);

            //CLEAR DUPLICATES
            html_all = html_all.Distinct().ToList(); //REMOVE SAME URLS

            return html_all;
        }

        private static List<string> html_get_everyobject_in_apostrophes(char[] htmlChars)
        {
            //get urls like this: blablablablablablabla "some url we want" blablablablabla

            List<string> links = new List<string>();
            string link = "";
            bool afterQuote = false;
            foreach (char ch in htmlChars)
            {
                if (ch == '\'')
                {
                    afterQuote = !afterQuote;

                    if (!afterQuote)
                    {
                        links.Add(link);
                        link = "";
                    }
                }
                else if (afterQuote)
                {
                    link = link + ch; //add chars to string after quote
                }
            }

            return links;
        }

        private static List<string> html_get_everyobject_in_quotes(char[] htmlChars)
        {
            //get urls like this: blablablablablablabla "some url we want" blablablablabla

            List<string> links = new List<string>();
            string link = "";
            bool afterQuote = false;
            foreach (char ch in htmlChars)
            {
                if (ch == '"')
                {
                    afterQuote = !afterQuote;

                    if (!afterQuote)
                    {
                        links.Add(link);
                        link = "";
                    }
                }
                else if (afterQuote)
                {
                    link = link + ch; //add chars to string after quote
                }
            }

            return links;
        }
    }
}