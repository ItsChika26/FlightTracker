using System.Text;
namespace Flight_Project
{
    public class NewsGenerator(List<IReportable> reportables, List<INewsProvider> newsProviders)
    {
        private List<IReportable> Reportables { get; } = reportables;
        private List<INewsProvider> NewsProviders { get; } = newsProviders;

        public IEnumerable<string?> GenerateNextNews()
        {
            foreach (var provider in NewsProviders)
            {
                foreach (var reportable in Reportables)
                {
                    yield return reportable.AcceptNewsProvider(provider);
                }
            }
        }

        public string GenerateAllNews()
        {
            StringBuilder allNews = new StringBuilder();
            foreach (var news in GenerateNextNews())
            {
                allNews.AppendLine(news);
            }
            return allNews.ToString();
        }
    }
}
