# metadata-global-nav-sp2013
SharePoint Managed Metadata Global Navigation Control

## Getting Started

Build and deploy solution 
````
[placeholer]
````
In the example, below, we will deploy one of the three controls included in this solution.
Note that each navigaition control is hard coded to look for a specific term group name: 

| Control Name | Term Group | Term Set |
|---|---|---|
| PortalGlobalNav  | Portal     | GlobalNav|
| SearchGlobalNav  | Search     | GlobalNav|
| RecordsGlobalNav | Records    | GlobalNav|


Include the control in Masterpage

Register control in Masterpage
````
<%@ Register TagPrefix="GlobalNav"  TagName="PortalGlobalNav" Src="~/_controltemplates/GlobalNav/PortalGlobalNav.ascx" %>
````
Call control 
````
<div class="portalNavigation">
  <GlobalNav:PortalGlobalNav id="PortalGlobalNav" EnableViewState="true" runat="server" />
</div>
````
Customize navigation Css (either edit an exiting css file or ref a new link from your masterpage)
````
/**************************************/
/* Global Navigation                  */
/**************************************/
.PortalNavContainer{
        display:inline-block;
        vertical-align:top;
        position:relative;
        float:left;
/*      background:linear-gradient(#d8ab4c 10%, #fab72a 50%, #d8ab4c 90%); */
        height:30px;
        margin-left:30px;
}

.GlobalNav{
        margin:0;
        padding:0;
        list-style:none;
}

.GlobalNav a{
        display:block;
}

.GlobalNav li a{
        color:white;
        font-style:italic;
        font-size:16px;
             font-family:"Franklin Gothic Heavy";

}

.GlobalNav a:link,.GlobalNav a :visited,.GlobalNav a:active,.GlobalNav a:hover{
        text-decoration:none !important;
}

.GlobalNav li a:hover{
        color:#000;
}

.GlobalNav li{
        float:left;
        padding:0px 0px 0px 10px;
        margin: 0px -30px 0px 0px;
        transition:all 1s;

}
.GlobalNav li:hover{
        transition:all 1s;
        margin-right:-10px;
        margin-left:20px;
}

.GlobalNav>li>a>img{
        width:60px;
        height:60px;
        background:transparent cover ;
        border-radius:30px;
        /*box-shadow:-3px 3px 5px black;*/
        opacity:0.8;

}

.GlobalNav>li>ul>li>a>img{
        width:30px;
        height:30px;
        background:transparent no-repeat ;
        border-radius:15px;
        /*box-shadow:-3px 3px 5px black;*/


}

.GlobalNav>li>a>img:hover{
        opacity:1.0;
}

.GlobalNav ul{
        display:none;
        background:#fcfcfc;
        border:1px solid #eee;
        box-shadow:1px 1px 7px #ccc;
        z-index:10000;
}

.GlobalNav ul li{
        position:relative;
        display:block;
        width:180px;
}

.GlobalNav ul li:hover{
        background:#eee;
        color:#000;
}

.GlobalNav>ul{
        display:block;
}

.GlobalNav>ul li{
        display:block;
}

.GlobalNav>li:hover>ul{
        display:block;
        position:absolute;
        width:200px;
}

.GlobalNav>li ul li:hover>ul{
        display:block;
        position:absolute;
        width:200px;
        right:-200px;
        top:0;
}
````

### Prerequisites

It's very helpful if you have access to SharePoint 2013, since this is a 15 hive solution.
Although the generated project will work with SharePoint 2016, it is not optimized for SharePoint 2016.


## Authors

* **Kayode Bristol** 

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details


