namespace EMS.Common.Interfaces
{
    public interface IRestApiCaller
    {
        T Get<T>(string baseAddress, string apiUrl);


        T2 Post<T1, T2>(string baseAddress, string apiUrl, T1 postObject);


        T2 Put<T1, T2>(string baseAddress, string apiUrl, T1 putObject);


        void Delete(string baseAddress, string apiUrl);

    }
}
