using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Html;

namespace TechEd.Services
{
    public class SearchResult
    {
        public string ItemLink
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public DateTime PublishedDate
        {
            get;
            set;
        }

        public string Authors
        {
            get;
            set;
        }

        public string Body
        {
            get;
            set;
        }

        public string BodyDocument
        {
            get
            {
                return "<html><style>body { font-family: 'Segoe UI'; }</style><body>" + Body + "</body></html>";
            }
        }

        public string BodyText
        {
            get
            {
                return HtmlUtilities.ConvertToText(Body);
            }
        }

        public string LargeThumbnail
        {
            get;
            set;
        }

        public string SmallThumbnail
        {
            get;
            set;
        }

        public bool HasSmallThumbnail 
        {
            get
            {
                return !String.IsNullOrEmpty(SmallThumbnail);
            }
        }

        public string VideoMP4Medium
        {
            get;
            set;
        }

        public string VideoMP4High
        {
            get;
            set;
        }
    }
}
