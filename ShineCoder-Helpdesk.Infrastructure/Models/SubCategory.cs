 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineCoder_Helpdesk.Infrastructure.Models
{
    public class SubCategory : BaseEntity
    {
        public string Name { get; set; }

		[ForeignKey(nameof(Category))]
		public Int32 CategoryId { get; set; }
		public Category Category { get; set; }
    }
}
