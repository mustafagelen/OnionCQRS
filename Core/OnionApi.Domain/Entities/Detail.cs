using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Domain.Entities
{
    public class Detail
    {

        public Detail()
        {
            
        }
        public Detail(int categoryId, string title, string description)
        {
            Description = description;
            Title = title;
            CategoryId = categoryId;
        }
        public required int CategoryId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required Category Category { get; set; }

    }
}
