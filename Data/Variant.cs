using System.ComponentModel.DataAnnotations;

namespace WebTeploobmenApp.Data
{
    public class Variant : Formulas.Data
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }

        public Variant() { }
        public Variant(Formulas.Data copy) : base(copy) { }
    }
}
