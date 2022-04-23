using DelegatesNetCore6.Models;
using System;

public class OrderProcessor
{
     
    public Func<Order, bool>  OnOrderInitialized{get; set; }
    
    private void Initialize(Order order)
    {
        
        ArgumentNullException.ThrowIfNull(order);
        if (OnOrderInitialized?.Invoke(order) == false)
        {
            throw new Exception($"Couldn't init the order {order.IdNumber}");
        }
    }
   
    public void Process(Order order,Action<Order> onCompleted = default)
    {
        
        Initialize(order);
        onCompleted?.Invoke(order);
    }
}