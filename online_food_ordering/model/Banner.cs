using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace online_food_ordering.model
{
    public class Banner
    {
        private int id;
        private string image;
        private string heading;
        private string sub_heading;
        private string link;
        private string link_text;
        private int banner_order;
        private DateTime added_on;
        private byte status;

        public Banner()
        {
            id = 0;
            image = string.Empty;
            heading = string.Empty;
            sub_heading = string.Empty;
            link = string.Empty;
            link_text = string.Empty;
            banner_order = 0;
        }
        public Banner(int id, string image, string heading, string sub_heading, string link, string link_text, int banner_order, DateTime added_on, byte status)
        {
            this.id = id;
            this.image = image;
            this.heading = heading;
            this.sub_heading = sub_heading;
            this.link = link;
            this.link_text = link_text;
            this.banner_order = banner_order;
            this.added_on = added_on;
            this.status = status;
        }
        public Banner(string image, string heading, string sub_heading, string link, string link_text, int banner_order, DateTime added_on, byte status)
        {
            this.image = image;
            this.heading = heading;
            this.sub_heading = sub_heading;
            this.link = link;
            this.link_text = link_text;
            this.banner_order = banner_order;
            this.added_on = added_on;
            this.status = status;
        }
        public int GetId() => id;
        public void SetId(int id) => this.id = id;
        public string GetImage() => image;
        public void SetImage(string image) => this.image = image;
        public string GetHeading() => heading;
        public void SetHeading(string heading) => this.heading = heading;
        public string GetSubHeading() => sub_heading;
        public void SetSubHeading(string sub_heading) => this.sub_heading = sub_heading;
        public string GetLink() => link;
        public void SetLink(string link) => this.link = link;
        public string GetLinkText() => link_text;
        public void SetLinkText(string link_text) => this.link_text = link_text;
        public int GetBannerOrder() => banner_order;
        public void SetBannerOrder(int banner_order) => this.banner_order = banner_order;
        public DateTime GetAddedOn() => added_on;
        public void SetAddedOn(DateTime added_on) => this.added_on = added_on;
        public byte GetStatus() => status;
        public void SetStatus(byte status) => this.status = status;
    }
}