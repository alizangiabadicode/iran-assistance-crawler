using HtmlAgilityPack;
using System;
using System.Linq;
using System.Net.Http;
using static System.Console;
using System.IO;
using System.Collections.Generic;
using web_crawler_using_cSharp.Model;
using Newtonsoft;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace web_crawler_using_cSharp
{
    class Program
    {
        //LoadNextPage page = new LoadNextPage();
        static void Main(string[] args)
        {
            Program obj = new Program();
            obj.StartCrawling().GetAwaiter().GetResult();
            Console.ReadKey();
        }

        public async Task StartCrawling()
        {
            List<RowOfTable> Rows = new List<RowOfTable>();
            string errors = "";
            //int PageNumber = 1;
            int LastPageNumber = 50;
            for (int PageNumber = 1; PageNumber <= LastPageNumber; PageNumber++)
            {

                var pageHTML = LoadNextPage.Next(PageNumber);
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(pageHTML);
                var section = htmlDocument
                    .DocumentNode;
                //WriteLine(section.InnerHtml);

                WriteLine("break");
                try
                {

                    var nodes = section.SelectNodes("//div[@class='sos-table-wrapper sos-table-mod2 sos-main-font']/div[@class='sos-table-row sos-rtl-right']");
                    foreach (var n in nodes)
                    {
                        RowOfTable row = new RowOfTable();
                        WriteLine("row");
                        var children = n.ChildNodes.Where(n => n.Name != "#text").ToList();
                        row.OnvaneMarKazeDarmani = (children[0].InnerText.Trim());
                        row.NoeGhararDad = (children[1].InnerText.Trim());
                        row.Ostan = (children[2].InnerText.Trim());
                        row.SodureMoarefiName = (children[4].Element("div").Element("i").Attributes["title"].Value);
                        row.SodureOnlineMoarefiName = (children[5].Element("div").Element("i").Attributes["title"].Value);
                        //WriteLine(children[0].InnerText.Trim());
                        //WriteLine(children[1].InnerText.Trim());
                        //WriteLine(children[2].InnerText.Trim());
                        //WriteLine(children[3].InnerText.Trim());
                        //WriteLine(children[4].Element("div").Element("i").Attributes["title"].Value);
                        //WriteLine(children[5].Element("div").Element("i").Attributes["title"].Value);
                        //WriteLine(children[6].Element("div").Element("a").Attributes["href"].Value);
                        var detail = LoadNextPage.Detail(children[6].Element("div").Element("a").Attributes["href"].Value.Split("/")[3]);
                        HtmlDocument detailDocument = new HtmlDocument();
                        detailDocument.LoadHtml(detail);
                        var detailChildren = detailDocument.DocumentNode.SelectNodes("//body/div/dl");
                        try
                        {

                            foreach (var d in detailChildren)
                            {
                                WriteLine("row children");
                                var children2 = d.ChildNodes.Where(e => e.Name != "#text").ToList();
                                //WriteLine(children2[3].InnerText.Trim());
                                //WriteLine(children2[4].InnerText.Trim());
                                row.Shahr = (children2[5].InnerText.Trim());
                                row.Address = (children2[7].InnerText.Trim());
                                row.Telephone = (children2[9].InnerText.Trim());
                                row.WebSite = (children2[17].InnerText.Trim());
                                //WriteLine(children2[5].InnerText.Trim());
                                //WriteLine(children2[6].InnerText.Trim());
                                //WriteLine(children2[7].InnerText.Trim());
                                //WriteLine(children2[8].InnerText.Trim());
                                //WriteLine(children2[15].InnerText.Trim());
                                //WriteLine(children2[16].InnerText.Trim());
                                //WriteLine(children2[17].InnerText.Trim());
                                //WriteLine(children2[18].InnerText.Trim());
                                //WriteLine(children2[19].InnerText.Trim());
                                //WriteLine(children2[20].InnerText.Trim());
                            }
                        }
                        catch (Exception)
                        {
                            errors += $"error on page = ${PageNumber}, on item => name = {row.OnvaneMarKazeDarmani}\n";
                        }

                        Rows.Add(row);
                    }
                }
                catch (Exception)
                {
                    errors += $"error on page = {PageNumber}\n";
                }

            }

            string json = JsonConvert.SerializeObject(Rows);
            WriteLine(json);
            WriteLine(errors);
        }
    }
}


//public async Task StartCrawling()
//{
//    List<RowModel> rows = new List<RowModel>();
//    int i = 1;
//    LoadNextPage.Next(i);
//    var stringHtml = File.ReadAllText("D:/مراکز درمانی طرف قرارداد - کمک رسان ایران.html");
//    var htmlParser = new HtmlDocument();
//    htmlParser.LoadHtml(stringHtml);
//    var section = htmlParser
//        .DocumentNode
//        .Descendants("section")
//        .FirstOrDefault(e => e.Id == "sos-medical-centers-table");
//    var divs = section.Descendants(3).Where(e => e.HasClass("sos-table-row")).ToList();
//    divs.ForEach((v) =>
//    {
//        //WriteLine("\ndiv\n");
//        var childDivs = v.Descendants("div").Where(e => e.HasClass("sos-col")).ToList();
//        RowModel row = new RowModel();
//        for (int i = 0; i < childDivs.Count; i++)
//        {
//            if (i == 0)
//            {
//                row.DoctorName = childDivs[0].InnerText.Trim();
//            }
//            else if (i == 1)
//            {
//                row.Job = childDivs[1].InnerText.Trim();
//            }
//            else if (i == 2)
//            {
//                row.Address = childDivs[2].InnerText.Trim();
//            }
//            else if (i == 4)
//            {
//                var div2 = childDivs[4].Descendants("div").FirstOrDefault(e => e.HasClass("sos-td"));
//                //var ii = div2.Descendants("i").FirstOrDefault(e => e.HasClass("fa fa-check-circle"));
//                row.CanIntroduce = div2.FirstChild.NextSibling.Attributes.FirstOrDefault(e => e.Name == "title").Value.Trim();
//            }
//            else if (i == 5)
//            {
//                var div2 = childDivs[5].Descendants("div").FirstOrDefault(e => e.HasClass("sos-td"));
//                //var ii = div2.Descendants("i").FirstOrDefault(e => e.HasClass("fa fa-check-circle"));
//                row.CanIntroduceOnline = div2.FirstChild.NextSibling.Attributes.FirstOrDefault(e => e.Name == "title").Value.Trim();
//            }
//            else if (i == 6)
//            {
//                var div2 = childDivs[6].Descendants("div").FirstOrDefault(e => e.HasClass("sos-td"));
//                //var ii = div2.Descendants("a").FirstOrDefault(e => e.HasClass("fancybx"));
//                row.MoreInfoUrl = div2.FirstChild.Attributes.FirstOrDefault(e => e.Name == "href").Value.Trim();
//            }
//        }
//        WriteLine(row.ToString());
//        rows.Add(row);

//        string json = JsonConvert.SerializeObject(rows);
//        WriteLine(json);
//    });
//}
