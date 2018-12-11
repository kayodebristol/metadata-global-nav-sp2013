using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Taxonomy;

namespace MetaDataGlobalNavigation.ControlTemplates
{
    public partial class JNCCAGlobalNav : UserControl
    {
        public static string html { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite thisSite = new SPSite(SPContext.Current.Site.WebApplication.AlternateUrls[0].Uri.AbsoluteUri))
                    {
                        html = "";
                        TaxonomySession session = new TaxonomySession(thisSite);
                        TermStoreCollection store = session.TermStores;

                        try
                        {
                            foreach (TermStore termStore in session.TermStores)
                            {
                                Group navGroup = termStore.Groups["JNCC-A"];
                                TermSet topSet = navGroup.TermSets["GlobalNav"];
                                html += writeTerms(topSet.Terms);
                            }
                        }
                        catch
                        {
                        }

                        finally
                        {
                            JNCCANavContainer.Text = "";
                            JNCCANavContainer.Text = html;
                        }
                    }
                });
            }
        }

        public string writeTerms(TermCollection terms)
        {
            if (terms.Count > 0)
            {
                html += "\n<ul class=\"GlobalNav\">\n";
                foreach (Term subTerm in terms)
                {
                    String hoverText = "";
                    String hyperLink = "";
                    String imgURL = "";
                    try
                    {
                        hoverText = (subTerm.LocalCustomProperties["_Sys_Nav_HoverText"] != null) ? subTerm.LocalCustomProperties["_Sys_Nav_HoverText"] : "";
                    }
                    catch
                    {
                        hoverText = "";

                    }
                    if (subTerm.CustomProperties.TryGetValue("imgURL", out imgURL))
                    {
                        try
                        {

                            hyperLink = (subTerm.LocalCustomProperties["_Sys_Nav_SimpleLinkUrl"] != null) ? subTerm.LocalCustomProperties["_Sys_Nav_SimpleLinkUrl"] : "#";
                            html += "<li><a href=\"" + hyperLink + "\" " + "title=\"" + hoverText + "\">" + "<img src=\"" + imgURL + "\" alt=\"" + subTerm.Name + "\" height=\"150\" width=\"150\"></a>";
                            writeTerms(subTerm.Terms);
                            html += "</li>\n";
                        }
                        catch
                        {
                            html += "<li><a href=\"#\">" + subTerm.Name + "</a>";
                            writeTerms(subTerm.Terms);
                            html += "</li>\n";
                        }
                    }
                    else
                    {


                        try
                        {

                            hyperLink = (subTerm.LocalCustomProperties["_Sys_Nav_SimpleLinkUrl"] != null) ? subTerm.LocalCustomProperties["_Sys_Nav_SimpleLinkUrl"] : "#";
                            html += "<li><a href=\"" + hyperLink + "\" " + "title=\"" + hoverText + "\">" + subTerm.Name + "</a>";
                            writeTerms(subTerm.Terms);
                            html += "</li>\n";
                        }

                        catch
                        {
                            html += "<li><a href=\"#\">" + subTerm.Name + "</a>";
                            writeTerms(subTerm.Terms);
                            html += "</li>\n";
                        }

                    }

                }

                html += "</ul>\n";
            }
            return html;
        }
    }
}