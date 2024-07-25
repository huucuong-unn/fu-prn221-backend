namespace JewelryProduction.Service.Constant
{
    public static class ApiEndPointConstant
    {
        static ApiEndPointConstant()
        {
        }

        public static class User
        {
            public const string GET_USER = "api/v1/user";
            public const string GET_USER_BY_ID = "api/v1/user/";
            public const string CREATE_USER = "api/v1/user/create";
            public const string UPDATE_USER = "api/v1/user/update";
            public const string CHANGE_STATUS_USER = "api/v1/user/change-status";
            public const string GET_STAFF = "api/v1/staff";
        }

        public static class Customer
        {
            public const string GET_CUSTOMER = "api/v1/customer";
            public const string GET_CUSTOMER_BY_ID = "api/v1/customer/";
            public const string CREATE_CUSTOMER = "api/v1/customer/create";
            public const string UPDATE_CUSTOMER = "api/v1/customer/update";
            public const string CHANGE_STATUS_CUSTOMER = "api/v1/customer/change-status";
            public const string GET_CUSTOMER_BY_PHONE = "api/v1/customer/phone";

        }


        public static class Order
        {
            public const string GET_ORDER = "api/v1/order";
            public const string STATISTICAL_ORDER_SALES_PRODUCT = "api/v1/order/statistical-order-sales-product";
            public const string ORDER_DASHBOARD_FOR_LINE_CHART = "api/v1/order/dashboard-line-chart";
            public const string ORDER_DASHBOARD_FOR_BAR_CHART = "api/v1/order/dashboard-bar-chart";
            public const string ORDER_DASHBOARD_FOR_PIE_CHART = "api/v1/order/dashboard-pie-chart";
            public const string ORDER_TOP_5_CUSTOMER = "api/v1/order/top-5-customer";
            public const string GET_ORDER_BY_ID = "api/v1/order/";
            public const string CREATE_ORDER = "api/v1/order/create";
            public const string UPDATE_ORDER = "api/v1/order/update";
            public const string DELETE_ORDER = "api/v1/order/delete";
            public const string GET_ORDER_SEARCH = "api/v1/order-search";

        }

        public static class OrderItem
        {
            public const string GET_ORDERITEM = "api/v1/orderitem";
            public const string GET_ORDERITEM_BY_ID = "api/v1/orderitem/";
            public const string CREATE_ORDERITEM = "api/v1/orderitem/create";
            public const string UPDATE_ORDERITEM = "api/v1/orderitem/update/";
            public const string CHANGE_STATUS_ORDERITEM = "api/v1/orderitem/change-status/";
        }

        public static class Counter
        {
            public const string GET_COUNTER = "api/v1/counter";
            public const string GET_COUNTER_WITHOUT_PAGING = "api/v1/counter-without-paging";
            public const string GET_COUNTER_BY_ID = "api/v1/counter/";
            public const string CREATE_COUNTER = "api/v1/counter/create";
            public const string UPDATE_COUNTER = "api/v1/counter/update/";
            public const string CHANGE_STATUS_COUNTER = "api/v1/counter/change-status/";

        }

        public static class Material
        {
            public const string GET_MATERIAL_WITHOUT_PAGING = "api/v1/material-without-paging";
        }


        public static class UserCounter
        {
            public const string GET_USER_COUNTER = "api/v1/user-counter";
            public const string GET_USER_COUNTER_BY_ID = "api/v1/user-counter/";
            public const string GET_USER_COUNTER_BY_COUNTER_ID = "api/v1/user-counter/counter/";
            public const string CREATE_USER_COUNTER = "api/v1/user-counter/create";
            public const string UPDATE_USER_COUNTER = "api/v1/user-counter/update/";
            public const string CHANGE_STATUS_USER_COUNTER = "api/v1/user-counter/change-status/";
        }

        public static class Warranty
        {
            public const string GET_WARRANTY = "api/v1/warranty";
            public const string GET_WARRANTY_BY_ID = "api/v1/warranty/";
            public const string CREATE_WARRANTY = "api/v1/warranty/create";
            public const string UPDATE_WARRANTY = "api/v1/warranty/update/";
            public const string CHANGE_STATUS_WARRANTY = "api/v1/warranty/change-status/";
        }

        public static class Promotion
        {
            public const string GET_PROMOTION = "api/v1/promotion";
            public const string GET_PROMOTION_SEARCH = "api/v1/promotion/promotion-search";
            public const string GET_PROMOTION_BY_ID = "api/v1/promotion/";
            public const string CREATE_PROMOTION = "api/v1/promotion/create";
            public const string UPDATE_PROMOTION = "api/v1/promotion/update/";
            public const string CHANGE_STATUS_PROMOTION = "api/v1/promotion/change-status/";
        }

        public static class Stone
        {
            public const string GET_STONE = "api/v1/stone";
            public const string GET_STONE_WITHOUT_PAGING = "api/v1/stone/without-paging";
            public const string GET_STONE_BY_ID = "api/v1/stone/";
            public const string CREATE_STONE = "api/v1/stone/create";
            public const string UPDATE_STONE = "api/v1/stone/update/";
            public const string CHANGE_STATUS_STONE = "api/v1/stone/change-status/";

        }

        public static class Product
        {
            public const string GET_PRODUCT = "api/v1/product";
            public const string GET_PRODUCT_BY_ID = "api/v1/product/";
            public const string CREATE_PRODUCT = "api/v1/product/create";
            public const string UPDATE_PRODUCT = "api/v1/product/update/";
            public const string UPDATE_PRODUCT_PRICE = "api/v1/product/update-price";
            public const string CHANGE_STATUS_PRODUCT = "api/v1/product/change-status/";
            public const string TOTAL_PRODUCTS = "api/v1/product/total";
            public const string GET_PRODUCTS_ACTIVE = "api/v1/product/product-active";
            public const string SEARCH_PRODUCTS_BY_PRODUCT_TYPE_NAME = "api/v1/product/search/product-type-name/";
            public const string SEARCH_PRODUCTS_BY_PRODUCT_CODE = "api/v1/product/search/product-code/";
            public const string SEARCH_PRODUCTS_BY_MATERIAL_NAME = "api/v1/product/search/material-name/";
            public const string SEARCH_PRODUCTS_BY_COUNTER_NAME = "api/v1/product/search/counter-name/";
            public const string SEARCH_PRODUCTS_BY_PRODUCT_PRICE = "api/v1/product/search/product-price/";
            public const string SEARCH_SORT_PRODUCT = "api/v1/product/searchsort";
            public const string GET_PRODUCTS_FOR_MAKE_ORDER = "api/v1/product/product-for-order";
            public const string RECAL_PRODUCT = "api/v1/product/recal";

        }

        public static class ProductStone
        {
            public const string GET_PRODUCT_STONE = "api/v1/product-stone";
            public const string GET_PRODUCT_STONE_BY_PRODUCTID_AND_STONEID = "api/v1/product-stone/";
            public const string CREATE_PRODUCT_STONE = "api/v1/product-stone/create";
            public const string UPDATE_PRODUCT_STONE = "api/v1/product-stone/update/";
            public const string DELETE_PRODUCT_STONE = "api/v1/product-stone/delete/";
            public const string TOTAL_PRODUCT_STONE = "api/v1/product-stone/total";
        }

        public static class ProductType
        {
            public const string GET_PRODUCT_TYPE = "api/v1/product-type";
            public const string GET_PRODUCT_TYPE_WITHOUT_PAGING = "api/v1/product-type-without-paging";
            public const string GET_PRODUCT_TYPE_BY_ID = "api/v1/product-type/";
            public const string CREATE_PRODUCT_TYPE = "api/v1/product-type/create";
            public const string UPDATE_PRODUCT_TYPE = "api/v1/product-type/update/";
            public const string CHANGE_STATUS_PRODUCT_TYPE = "api/v1/product-type/change-status/";
            public const string TOTAL_PRODUCT_TYPES = "api/v1/product-type/total";
        }

        public static class RequestPromotion
        {
            public const string GET_REQUEST_PROMOTION = "api/v1/request-promotion";
            public const string GET_REQUEST_PROMOTIONS = "api/v1/request-promotions";
            public const string CREATE_REQUEST = "api/v1/request-promotion/create";
            public const string CHANGE_STATUS_REQUEST_PROMOTION = "api/v1/request-promotion/change-status/";
        }
    }
}
