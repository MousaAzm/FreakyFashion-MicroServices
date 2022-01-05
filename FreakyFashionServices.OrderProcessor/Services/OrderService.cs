
using AutoMapper;
using FreakyFashionServices.OrderProcessor.Data;
using FreakyFashionServices.OrderProcessor.Models.DbModel;
using FreakyFashionServices.OrderProcessor.Models.Dtos;
using FreakyFashionServices.OrderService.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreakyFashionServices.OrderProcessor.Services
{
    public class OrderService
    {
        private readonly OrderDbContext _context;
        
        public OrderService(OrderDbContext context)
        {
            _context = context;
        }

        public void CreateOrder(CreateOrderDto createOrderDto)
        {
            Thread.Sleep(2000);
            var getIdentifier = _context.Orders.FirstOrDefault(o => o.Identifier == createOrderDto.Identifier);
            if (getIdentifier != null)
            {
                _context.Orders.Remove(getIdentifier);
                _context.SaveChanges();
            }

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new OrderProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
                
            _context.Orders.Add(mapper.Map<Order>(createOrderDto));
            _context.SaveChanges();
            
        }

       
    }
}
