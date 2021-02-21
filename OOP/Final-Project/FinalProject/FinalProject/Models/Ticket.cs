using FinalProject.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FinalProject.Models
{
    public class Ticket
    {
        [Key]
        public int IdTicket { get; set; }
        [Required]
        [MaxLength(50)]
        public string TicketNumber { get; set; }
        [Range(1, 1500)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public int TicketClassAttributeId { get; set; }
        public int DiscountReasonId { get; set; }
        public int CustomerId { get; set; }
        public int DisplayingId { get; set; }

        [ForeignKey("TicketClassAttributeId")]
        public TicketClassAttribute TicketClassAttribute { get; set; }
        [ForeignKey("DiscountReasonId")]
        public DiscountReason DiscountReason { get; set; }
        [ForeignKey("CustomerId")]
        public User Customer { get; set; }
        [ForeignKey("DisplayingId")]
        public Displaying Displaying { get; set; }

        [EnumDataType(typeof(TicketStatus))]
        public TicketStatus TicketStatus { get; set; }
        [EnumDataType(typeof(TicketType))]
        public TicketType TicketType { get; set; }

        [NotMapped]
        public List<int> Seats { get; set; }

        public static Ticket BookTicket(User customer, Displaying displaying, List<int> seatIds)
        {
            var context = new DbService();

            var avs = context.AvialableSeats.Where(s => s.RideScheduleId == displaying.RideSchedule.IdRideSchedule);

            foreach(var av in avs)
            {
                if (seatIds.Contains(av.SeatId)) av.IsAvialable = false;
            }

            Ticket ticket = new Ticket()
            {
                TicketNumber = Guid.NewGuid().ToString(),
                CustomerId = customer.UserId,
                Price = displaying.StandardPrice,
                Seats = seatIds,
                TicketStatus = TicketStatus.Booked,
                TicketType = TicketType.Standard,
                TicketClassAttributeId = 2,
                DisplayingId = displaying.IdDisplaying,
                DiscountReasonId = 1
            };

            context.Tickets.Add(ticket);
            
            foreach(int seat in seatIds)
            {
                context.TicketSeats.Add(new TicketSeats
                {
                    Ticket = ticket,
                    SeatId = seat
                });
            }

            var d = context.Displayings.Where(s => s.IdDisplaying == displaying.IdDisplaying).FirstOrDefault();

            d.AvialableSeats -= seatIds.Count;

            context.SaveChanges();

            return ticket;
        }

    }
}
