// See https://aka.ms/new-console-template for more information
using FastBAI.Services;

Console.WriteLine("Hello, World!");
BaiFileService fileService = new BaiFileService();
fileService.ProcessFile(@"../../../Files/BAIDAY1.txt");
var baiFile = fileService.GetFile();
Console.WriteLine(baiFile.FileHeader.Groups?.First()?.Accounts?.First().AccountNumber);
