
var allowedFiles = new Dictionary<string, string>()
{
    {"jpg",  "FF-D8-FF-E0"},
    {"png",  "89-50-4E-47-0D-0A-1A-0A"},
    {"pdf",  "25-50-44-46-2D" }
};



string filePath1 = "Image.jpg";
var fileBytes_1 = GetHeaderBytes(filePath1);
string fileExtension_1 = GetFileFormat(fileBytes_1);
Console.WriteLine($"File 1, Format : {fileExtension_1}, Allowed : {AllowedFileExtension(fileExtension_1)}");



string filePath2 = "phpCode.jpg";
var fileBytes_2 = GetHeaderBytes(filePath2);
string fileExtension_2 = GetFileFormat(fileBytes_2);
Console.WriteLine($"File 2, Format : {fileExtension_2}, Allowed : {AllowedFileExtension(fileExtension_2)}");


string filePath3 = "Test.pdf";
var fileBytes_3 = GetHeaderBytes(filePath3);
string fileExtension_3 = GetFileFormat(fileBytes_3);
Console.WriteLine($"File 3, Format : {fileExtension_3}, Allowed : {AllowedFileExtension(fileExtension_3)}");


Console.ReadLine();


bool AllowedFileExtension(string fileExtension)
{
    return allowedFiles.ContainsKey(fileExtension);
}

byte[] GetHeaderBytes(string filePath)
{
    BinaryReader reader = new BinaryReader(new FileStream(Convert.ToString(filePath), FileMode.Open, FileAccess.Read, FileShare.None));
    reader.BaseStream.Position = 0;
    var initialBytes = reader.ReadBytes(10);
    reader.Close();
    return initialBytes;
}

string GetFileFormat(byte[] headerBytes)
{
    string headerHex = BitConverter.ToString(headerBytes);

    foreach (var fileFormat in allowedFiles)
    {
        if (headerHex.StartsWith(fileFormat.Value))
        {
            return fileFormat.Key;
        }
    }

    return "unknown";
}