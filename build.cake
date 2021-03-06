#addin "wk.StartProcess"
#addin "wk.ProjectParser"

using PS = StartProcess.Processor;
using ProjectParser;

var name = "TupleAwaiter";
var project = $"src/{name}/{name}.csproj";
var info = Parser.Parse(project);
var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
var currentDir = new System.IO.DirectoryInfo(".").FullName;

Task("Pack").Does(() => {
    CleanDirectory("publish");
    DotNetCorePack(project, new DotNetCorePackSettings {
        OutputDirectory = "publish"
    });
});

Task("Publish-Nuget")
    .IsDependentOn("Pack")
    .Does(() => {
        var npi = EnvironmentVariable("npi");
        var nupkg = new DirectoryInfo("publish").GetFiles("*.nupkg").LastOrDefault();
        var package = nupkg.FullName;
        NuGetPush(package, new NuGetPushSettings {
            Source = "https://www.nuget.org/api/v2/package",
            ApiKey = npi
        });
});

var target = Argument("target", "Pack");
RunTarget(target);