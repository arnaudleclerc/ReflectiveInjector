namespace Samples.WebApp.Business
{
    internal class DataBusiness: IDataBusiness
    {
        public string[] GetData()
        {
            return new []
            {
                "data1",
                "data2"
            };
        }
    }
}
