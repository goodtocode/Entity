

namespace GoodToCode.Entity.Person
{
    /// <summary>
    /// Gender Code
    /// </summary>        
    public interface IGenderId
    {
        /// <summary>
        /// Gender Id (ISO/IEC 5218)
        /// </summary>
        int GenderId { get; set; }
    }
}
