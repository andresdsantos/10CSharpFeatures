
using System;

using DelegatesNetCore6.Models;

    var order = new Order();
    order.IdNumber = System.Guid.NewGuid().ToString();
    order.Description = "Items ordered";
    order.IsReadyForShippment = true;

    var processor = new OrderProcessor
    {
        OnOrderInitialized = (order) => order.IsReadyForShippment
    };

    var  onCompleted =  (Order order) =>
    {
        Console.WriteLine($"Order processed {order.IdNumber}");
    };


    processor.Process(order,onCompleted);

   



