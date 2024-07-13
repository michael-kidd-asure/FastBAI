// See https://aka.ms/new-console-template for more information
using FastBAI.Services;

Console.WriteLine("Hello, World!");
BaiFileService service = new BaiFileService();
var file = service.ProcessFile(@"..\..\..\Files\BAIDAY1.txt");
Console.WriteLine(file.FileHeader.Groups.First().Accounts.First().AccountNumber);