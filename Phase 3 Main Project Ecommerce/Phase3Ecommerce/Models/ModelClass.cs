using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Phase3Ecommerce.Models
{
    public class lapmodel
    {
        [Required()]
        public int lapid
        {
            get;
            set;
        }
        [MaxLength(20, ErrorMessage = "Maximum 20 characters")]
        public string lapname
        {
            get;
            set;
        }
    }

    public class loginmodel
    {
        [Required()]
        public int custid
        {
            get;
            set;
        }
        [MaxLength(20, ErrorMessage = "Max words should be 20")]
        public string custname
        {
            get;
            set;
        }
    }

    public class ordermodel
    {
        [Required()]
        public int orderid
        {
            get;
            set;
        }
        public int custid
        {
            get;
            set;
        }
        public int lapid
        {
            get;
            set;
        }
        [DataType(DataType.DateTime)]
        public DateTime orderdate
        {
            get;
            set;
        }
        [DataType(DataType.DateTime)]
        public DateTime? receivedate
        {
            get;
            set;
        }
        public string comments
        {
            get;
            set;
        }
    }

}