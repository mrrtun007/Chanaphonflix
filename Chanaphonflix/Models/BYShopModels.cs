namespace Chanaphonflix.Models;

// API Product Response
public class BYShopProductResponse
{
    public string? status { get; set; }
    public List<BYShopProduct>? data { get; set; }
}

public class BYShopProduct
{
    public string? id { get; set; }
    public string? name { get; set; }
    public string? category { get; set; }
    public string? price { get; set; }
    public string? price_vip { get; set; }
    public string? stock { get; set; }
    public string? product_info { get; set; }
    public string? img { get; set; }
}

// API Buy Request
public class BYShopBuyRequest
{
    public string? keyapi { get; set; }
    public string? id { get; set; }
    public string? name { get; set; }
    public string? info { get; set; }
}

// API Buy Response
public class BYShopBuyResponse
{
    public string? status { get; set; }
    public string? message { get; set; }
    public BYShopBuyData? data { get; set; }
}

public class BYShopBuyData
{
    public string? order_id { get; set; }
    public string? name { get; set; }
    public string? email { get; set; }
    public string? password { get; set; }
    public string? profile { get; set; }
    public string? price { get; set; }
    public string? info { get; set; }
    public string? product_name { get; set; }
}

// API Money Check Response
public class BYShopMoneyResponse
{
    public string? status { get; set; }
    public string? money { get; set; }
}

// API History Response
public class BYShopHistoryResponse
{
    public string? status { get; set; }
    public List<BYShopHistoryData>? data { get; set; }
}

public class BYShopHistoryData
{
    public string? order_id { get; set; }
    public string? product_id { get; set; }
    public string? product_name { get; set; }
    public string? name { get; set; }
    public string? email { get; set; }
    public string? password { get; set; }
    public string? profile { get; set; }
    public string? info { get; set; }
    public string? price { get; set; }
    public string? status { get; set; }
    public string? date { get; set; }
    public string? report { get; set; }
    public string? status_fix { get; set; }
}
