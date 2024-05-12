using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReHub.DbDataModel.Models;

[Table("lesson_packages")]
[PrimaryKey("Id")]
public partial class LessonPackage
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("lessons_num")]
    public int LessonsNum { get; set; }

    [Column("cost")]
    public double Cost { get; set; }

    //[InverseProperty("LessonPackage")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    public override string ToString()
    {
        return $"LessonPackage(id={Id}, cost={Cost})";
    }

}
