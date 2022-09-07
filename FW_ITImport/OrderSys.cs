/* 
 Licensed under the Apache License, Version 2.0

 http://www.apache.org/licenses/LICENSE-2.0
 */
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace FW_ITImport
{
    [XmlRoot(ElementName = "user")]
    public class User
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "password")]
        public string Password { get; set; }

        private Ordersys m_parent;
        public void setParent(Ordersys p_parent)
        {
            m_parent = p_parent;
        }
    }

    [XmlRoot(ElementName = "users")]
    public class Users
    {
        [XmlElement(ElementName = "user")]
        public List<User> User { get; set; }
    }

    [XmlRoot(ElementName = "category")]
    public class Category
    {
        [XmlAttribute(AttributeName = "cid")]
        public string Cid { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        private Ordersys m_parent;
        public void setParent(Ordersys p_parent)
        {
            m_parent = p_parent;
        }
    }

    [XmlRoot(ElementName = "categories")]
    public class Categories
    {
        [XmlElement(ElementName = "category")]
        public List<Category> Category { get; set; }
    }

    [XmlRoot(ElementName = "product")]
    public class Product
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlAttribute(AttributeName = "pid")]
        public string Pid { get; set; }
        [XmlAttribute(AttributeName = "cid")]
        public string Cid { get; set; }
        [XmlAttribute(AttributeName = "location")]
        public string Location { get; set; }
        [XmlAttribute(AttributeName = "shelf")]
        public string Shelf { get; set; }

        private Ordersys m_parent;
        public void setParent(Ordersys p_parent)
        {
            m_parent = p_parent;
        }

        public Category Category
        {
            get
            {
                Category m_result = null;
                foreach (Category m_category in m_parent.Categories.Category)
                    if (m_category.Cid == Cid)
                        m_result = m_category;
                return m_result;
            }
        }
    }

    [XmlRoot(ElementName = "products")]
    public class Products
    {
        [XmlElement(ElementName = "product")]
        public List<Product> Product { get; set; }
    }

    [XmlRoot(ElementName = "customer")]
    public class Customer
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "address1")]
        public string Address1 { get; set; }
        [XmlElement(ElementName = "address2")]
        public string Address2 { get; set; }
        [XmlElement(ElementName = "address3")]
        public string Address3 { get; set; }
        [XmlAttribute(AttributeName = "custid")]
        public string Cid { get; set; }
        [XmlAttribute(AttributeName = "phone")]
        public string Phone { get; set; }

        private Ordersys m_parent;
        public void setParent(Ordersys p_parent)
        {
            m_parent = p_parent;
        }
    }

    [XmlRoot(ElementName = "customers")]
    public class Customers
    {
        [XmlElement(ElementName = "customer")]
        public List<Customer> Customer { get; set; }
    }

    [XmlRoot(ElementName = "supplier")]
    public class Supplier
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "address1")]
        public string Address1 { get; set; }
        [XmlElement(ElementName = "address2")]
        public string Address2 { get; set; }
        [XmlElement(ElementName = "address3")]
        public string Address3 { get; set; }
        [XmlAttribute(AttributeName = "suppid")]
        public string Suppid { get; set; }
        [XmlAttribute(AttributeName = "phone")]
        public string Phone { get; set; }

        private Ordersys m_parent;
        public void setParent(Ordersys p_parent)
        {
            m_parent = p_parent;
        }
    }

    [XmlRoot(ElementName = "suppliers")]
    public class Suppliers
    {
        [XmlElement(ElementName = "supplier")]
        public List<Supplier> Supplier { get; set; }
    }

    [XmlRoot(ElementName = "orderline")]
    public class Orderline
    {
        [XmlAttribute(AttributeName = "olid")]
        public string Olid { get; set; }
        [XmlAttribute(AttributeName = "pid")]
        public string Pid { get; set; }
        [XmlAttribute(AttributeName = "quantity")]
        public string Quantity { get; set; }

        private Order m_parent;
        public void setParent(Order p_parent)
        {
            m_parent = p_parent;
        }

        public Product Product
        {
            get
            {
                Product m_result = null;
                foreach (Product m_product in m_parent.Parent.Products.Product)
                    if (m_product.Pid == Pid)
                        m_result = m_product;
                return m_result;
            }
        }
    }

    [XmlRoot(ElementName = "order")]
    public class Order
    {
        [XmlElement(ElementName = "orderline")]
        public List<Orderline> Orderline { get; set; }
        [XmlAttribute(AttributeName = "oid")]
        public string Oid { get; set; }
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }
        [XmlAttribute(AttributeName = "custid")]
        public string Custid { get; set; }
        [XmlAttribute(AttributeName = "packedby")]
        public string Packedby { get; set; }

        private Ordersys m_parent;
        public void setParent(Ordersys p_parent)
        {
            m_parent = p_parent;
            foreach (Orderline m_child in Orderline)
                m_child.setParent(this);
        }

        public Ordersys Parent
        {
            get
            {
                return m_parent;
            }
        }

        public Customer Customer
        {
            get
            {
                Customer m_result = null;
                foreach (Customer m_customer in m_parent.Customers.Customer)
                    if (m_customer.Cid == Custid)
                        m_result = m_customer;
                return m_result;
            }
        }
    }

    [XmlRoot(ElementName = "orders")]
    public class Orders
    {
        [XmlElement(ElementName = "order")]
        public List<Order> Order { get; set; }
    }

    [XmlRoot(ElementName = "deliveryline")]
    public class Deliveryline
    {
        [XmlAttribute(AttributeName = "dlid")]
        public string Dlid { get; set; }
        [XmlAttribute(AttributeName = "pid")]
        public string Pid { get; set; }
        [XmlAttribute(AttributeName = "quantity")]
        public string Quantity { get; set; }

        private Delivery m_parent;
        public void setParent(Delivery p_parent)
        {
            m_parent = p_parent;
        }

        public Product Product
        {
            get
            {
                Product m_result = null;
                foreach (Product m_product in m_parent.Parent.Products.Product)
                    if (m_product.Pid == Pid)
                        m_result = m_product;
                return m_result;
            }
        }
    }

    [XmlRoot(ElementName = "delivery")]
    public class Delivery
    {
        [XmlElement(ElementName = "deliveryline")]
        public List<Deliveryline> Deliveryline { get; set; }
        [XmlAttribute(AttributeName = "did")]
        public string Did { get; set; }
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }
        [XmlAttribute(AttributeName = "suppid")]
        public string Suppid { get; set; }

        private Ordersys m_parent;
        public void setParent(Ordersys p_parent)
        {
            m_parent = p_parent;
            foreach (Deliveryline m_child in Deliveryline)
                m_child.setParent(this);
        }

        public Ordersys Parent
        {
            get
            {
                return m_parent;
            }
        }

        public Supplier Supplier
        {
            get
            {
                Supplier m_result = null;
                foreach (Supplier m_supplier in m_parent.Suppliers.Supplier)
                    if (m_supplier.Suppid == Suppid)
                        m_result = m_supplier;
                return m_result;
            }
        }
    }

    [XmlRoot(ElementName = "deliveries")]
    public class Deliveries
    {
        [XmlElement(ElementName = "delivery")]
        public List<Delivery> Delivery { get; set; }
    }

    [XmlRoot(ElementName = "ordersys")]
    public class Ordersys
    {
        [XmlElement(ElementName = "users")]
        public Users Users { get; set; }
        [XmlElement(ElementName = "categories")]
        public Categories Categories { get; set; }
        [XmlElement(ElementName = "products")]
        public Products Products { get; set; }
        [XmlElement(ElementName = "customers")]
        public Customers Customers { get; set; }
        [XmlElement(ElementName = "suppliers")]
        public Suppliers Suppliers { get; set; }
        [XmlElement(ElementName = "orders")]
        public Orders Orders { get; set; }
        [XmlElement(ElementName = "deliveries")]
        public Deliveries Deliveries { get; set; }

        public string nextOid()
        {
            int m_result = 0;
            foreach (Order m_order in Orders.Order)
                if (Convert.ToInt32(m_order.Oid) > m_result)
                    m_result = Convert.ToInt32(m_order.Oid);
            return (++m_result).ToString();
        }

        public string nextDid()
        {
            int m_result = 0;
            foreach (Delivery m_delivery in Deliveries.Delivery)
                if (Convert.ToInt32(m_delivery.Did) > m_result)
                    m_result = Convert.ToInt32(m_delivery.Did);
            return (++m_result).ToString();
        }

        public void setParents()
        {
            foreach (User m_child in Users.User)
                m_child.setParent(this);
            foreach (Category m_child in Categories.Category)
                m_child.setParent(this);
            foreach (Product m_child in Products.Product)
                m_child.setParent(this);
            foreach (Customer m_child in Customers.Customer)
                m_child.setParent(this);
            foreach (Supplier m_child in Suppliers.Supplier)
                m_child.setParent(this);
            foreach (Order m_child in Orders.Order)
                m_child.setParent(this);
            foreach (Delivery m_child in Deliveries.Delivery)
                m_child.setParent(this);
        }
    }

}
