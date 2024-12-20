﻿using Orders_Managment_System.Dtos;
using Orders_Managment_System.Interfaces;
using Orders_Managment_System.Models;

namespace Orders_Managment_System.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepositry _repositry;
        private readonly IOrderRepositry _orderRepositry;

        public PaymentService(IPaymentRepositry repositry , IOrderRepositry orderRepositry)
        {
            _repositry = repositry;
            _orderRepositry = orderRepositry;
        }
        public async Task ProcessPaymentAsync(int orderId, decimal amount)
        {
            var payment = new PaymentDto()
            {
                Amount = amount,
                Status = "Completed",
                CreatedAt = DateTime.Now
            };
           await _repositry.CreatePaymentAsync(payment);
            
            
        }

        public async Task UpdatePaymentStatusAsync(int paymentId, string status)
        {
            await _repositry.UpdatePaymentStatusAsync(paymentId, status);
        }
    }
}
