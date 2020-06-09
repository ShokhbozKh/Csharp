using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject05.Models
{
    [Table("Car")]
    class Car
    {
        [Key]
        public int IdCar { get; set; }

        public string Brand { get; set; }
        public double Engine { get; set; }
        public string Year { get; set; }
        public CarClass CarClass { get; set; }
        public string[] Photos { get; set; }
        [Required, MaxLength(500)]
        public string Description { get; set; }

        public DateTime PostedDate { get; set; }
        public DateTime RemovedDate { get; set; }

        public int AgentId { get; set; }
        [ForeignKey("AgentId")]
        public Agent Agent { get; set; }
    }

    enum CarClass
    {
        MICRO,
        SEDAN,
        HATCHBACK,
        ROADSTER,
        PICKUP,
        SUPERCAR,
        TRUCK,
        COUPE,
        CUV,
        CABRIOLET,
        MINITRUCK
    }
}
