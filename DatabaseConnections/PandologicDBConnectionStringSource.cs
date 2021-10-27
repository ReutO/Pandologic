using Processing;

namespace DatabaseConnections
{
    public class PandologicDBConnectionStringSource : ISourceGetter<string>
    {
        public string Get()
        {
            //should be in a different file and the file path sould be in appsettings.jsson, 
            //but for the sake of the task I did this as a source class and added the connection string hard coded
            return "Server=localhost;Integrated security=SSPI;database=Pandologic";
        }
    }
}
