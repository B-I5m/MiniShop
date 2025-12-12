using System.ComponentModel.DataAnnotations;

namespace MiniShopMVC.Models.Entities;

public class BaseEntity
{
    [Key] public long Id { get; set; }
}