using System;

namespace Fruitmarket.WebApp.Dto

{
    public record ProductDto(
        Guid Guid,
        string Name,
        decimal Price
    );




}