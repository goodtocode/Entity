using System;
using System.Linq;
using GoodToCode.Entity.Option;
using GoodToCode.Extensions;
using GoodToCode.Framework.Data;

namespace GoodToCode.Entity.Venture
{
    /// <summary>
    /// For one selection in a OptionGroup's properties
    /// </summary>
    public class VentureEntityOptionDto : EntityDto<VentureEntityOptionDto>, IVentureEntityOption
    {
        private readonly OptionGroupDto _group = new OptionGroupDto();
        private readonly IQueryable<OptionDto> _selections;

        /// <summary>
        /// VentureKey regarding this Option
        /// </summary>
        public Guid VentureKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Entity regarding this Option
        /// </summary>
        public Guid EntityKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Possible selections
        /// </summary>
        public IQueryable<OptionDto> Selections
        {
            get { return _selections; }
        }
        
        /// <summary>
        /// Group
        /// </summary>
        public OptionGroupDto Group
        {
            get { return _group; }
        }

        /// <summary>
        /// Option whose value is being selected
        /// </summary>
        public Guid OptionKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Selected value
        /// </summary>
        public string Value
        {
            get { return Selections.Where(x => x.Key == this.OptionKey).FirstOrDefault().Name; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public VentureEntityOptionDto()
            : base()
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        public VentureEntityOptionDto(IQueryable<OptionDto> selections)
            : base()
        {
            _selections = selections;
        }    }   
}