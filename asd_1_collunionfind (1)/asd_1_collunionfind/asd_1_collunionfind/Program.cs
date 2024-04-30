// See https://aka.ms/new-console-template for more information
using asd_1_collunionfind;
using asd_1_collunionfind.utils;

void RunApp(AbstractRunnableApp app)
{
    app.Run();
}

Logger.WriteLine("Start!\n");

//Logger.Write(1, 2, 3, new {name= "N", dat = "Data"}, "\n");

RunApp(new MainUnionFind());

Logger.WriteLine("Ok!");
