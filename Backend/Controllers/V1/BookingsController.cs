using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UE03_Eventmanagement_Backend._01_DB_Models;
using static KT_CE_Api.DTOs.V1.DTOs;

namespace KT_CE_Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BookingsController(IMapper mapper, AppDbContext context)
        {
            _context = context;
            _mapper = mapper;

            //SEED
            _context.Database.EnsureCreated();
            _context.SaveChanges();
        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetBookingDto>>> GetBookings()
        {
            var bookings = await _context.Bookings
                .Include(b => b.Room)
                .Include(b => b.LVA)
                .ToListAsync();

            return _mapper.Map<List<GetBookingDto>>(bookings);
        }

        // GET: api/Bookings/5
        [HttpGet("{RoomId}")]
        public async Task<ActionResult<IEnumerable<GetBookingDto>>> GetBookingsByRoom(int RoomId)
        {
            var room = _context.Rooms.FirstOrDefault(r=>r.Id == RoomId);


            if (room == null)
            {
                return NotFound();
            }

            var bookings = await _context.Bookings
                .Include(b => b.Room)
                .Include(b => b.LVA)
                .Where(b => b.RoomId == RoomId).ToListAsync();

            return _mapper.Map<List<GetBookingDto>>(bookings);
        }

        // PUT: api/Bookings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, UpdateBookingDto bookingDto)
        {
            if (id != bookingDto.Id)
            {
                return BadRequest();
            }

            var booking = await _context.Bookings.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            _mapper.Map(bookingDto, booking);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Bookings
        [HttpPost]
        public async Task<ActionResult<GetBookingDto>> PostBooking(CreateBookingDto bookingDto)
        {
            var booking = _mapper.Map<Booking>(bookingDto);

            var addedEntity = _context.Bookings.Add(booking);

            await _context.SaveChangesAsync();

            return  StatusCode(201,_mapper.Map<GetBookingDto>(addedEntity.Entity));
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.Id == id);
        }
    }
}
