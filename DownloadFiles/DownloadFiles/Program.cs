class Program
{
    static readonly HttpClient client = new HttpClient();

    static async Task DownloadFileAsync(string url, string localPath)
    {
        try
        {
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var bytes = await response.Content.ReadAsByteArrayAsync();

            await System.IO.File.WriteAllBytesAsync(localPath, bytes);
        }
        catch (Exception)
        {
            Console.WriteLine("Check the url");
        }
    }

    static async Task Main(string[] args)
    {
        //Information needed to locate the.pdf file.
        int [] Data = new[] { 1234, 2768, 1957, 9057, 8994 };

        string localPaths = "C:\\Users\\PC\\Documents\\Path"; //Replace with the local paths where you want to save the .pdf files

        string url = "";
        
        foreach (var moves in Data)
        {
            url = @$"https://test.dominio.com.br/Reportpdf.aspx?PDF={moves}";

            await DownloadFileAsync(url, $"{localPaths}\\data_{moves}.pdf");

            Console.WriteLine($"File: {localPaths}");
        }

        Console.WriteLine("Program finished.");
    }
}
