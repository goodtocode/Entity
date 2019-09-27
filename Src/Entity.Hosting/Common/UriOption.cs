using System;

namespace GoodToCode.Entity.Hosting
{
    public interface IUriOption
    {
        Uri Url { get; set; }
    }
    public class UriOption : IUriOption
    {
        public Uri Url { get; set; }
    }
}
