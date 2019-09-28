

using System;
using System.Linq;
using GoodToCode.Entity.Option;
using GoodToCode.Extensions;
using GoodToCode.Framework.Data;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// For one selection in a OptionGroup's properties
    /// </summary>
    public class EventEntityOptionDto : EntityDto<EventEntityOptionDto>, IEventEntityOption
    {
        private readonly OptionGroupDto _group = new OptionGroupDto();
        private readonly IQueryable<OptionDto> _selections;

        /// <summary>
        /// EventKey regarding this Option
        /// </summary>
        public Guid EventKey { get; set; } = Defaults.Guid;

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
        public EventEntityOptionDto()
            : base()
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        public EventEntityOptionDto(IQueryable<OptionDto> selections)
            : base()
        {
            _selections = selections;
        }    }   
}