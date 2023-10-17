using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Helper.TemplateEmail
{
    public class EmailMessageTemplate
    {
        private readonly IResourceHandler _resourceHandler;
        public EmailMessageTemplate(IResourceHandler resourceHandler)
        {
            _resourceHandler = resourceHandler;
        }
		public EmailMessageTemplate() { }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string EmailTemplateSetting { get; set; }
        public string Subject => _resourceHandler.GetInfo("ContactUsMsg");
        public string SubjectMessage { get; set; }
        public string BodyMessage { get; set; }
        public string ApiUrl { get; set; }
        public string JizanWebsite { get; set; }
        public DateTime Date { get; set; }



        public string Body => $@"<html lang=""ar"" dir=""rtl"" xmlns=""http://www.w3.org/1999/xhtml"" xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:o=""urn:schemas-microsoft-com:office:office"">
<head>
    <meta charset=""utf-8"">
    <meta name=""viewport"" content=""width=device-width""> 
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge""> 
    <meta name=""x-apple-disable-message-reformatting"">  
    <title></title> 

    <style>
@import url('https://fonts.googleapis.com/css2?family=Cairo:wght@400;500;700&display=swap');

		/****fonts***/
		.font-regular {{
		font-family: 'Cairo', sans-serif;
		font-weight: 400;
		font-style: normal;
		}}
		.font-medium {{
		font-family: 'Cairo', sans-serif;
		font-weight: 500;
		}}
		.font-bold {{
		font-family: 'Cairo', sans-serif;
		font-weight: 700;
		font-style: bold;
		}}

		*{{
			font-family: 'Cairo', sans-serif;
			font-weight: 400;
			}}
        html,
body {{
    margin: 0 auto !important;
    padding: 0 !important;
    height: 100% !important;
    width: 100% !important;
    background: #f1f1f1;
}}
* {{
    -ms-text-size-adjust: 100%;
    -webkit-text-size-adjust: 100%;
    direction: rtl;


}}

div[style*=""margin: 16px 0""] {{
    margin: 0 !important;
}}

table,
td {{
    mso-table-lspace: 0pt !important;
    mso-table-rspace: 0pt !important;
}}

table {{
    border-spacing: 0 !important;
    border-collapse: collapse !important;
    table-layout: fixed !important;
    margin: 0 0 !important;
}}

img {{
    -ms-interpolation-mode:bicubic;
}}
a {{
    text-decoration: none;
}}
*[x-apple-data-detectors],  /* iOS */
.unstyle-auto-detected-links *,
.aBn {{
    border-bottom: 0 !important;
    cursor: default !important;
    color: inherit !important;
    text-decoration: none !important;
    font-size: inherit !important;
    font-family: inherit !important;
    font-weight: inherit !important;
    line-height: inherit !important;
}}

.a6S {{
    display: none !important;
    opacity: 0.01 !important;
}}
.im {{
    color: inherit !important;
}}
img.g-img + div {{
    display: none !important;
}}
@media only screen and (min-device-width: 320px) and (max-device-width: 374px) {{
    u ~ div .email-container {{
        min-width: 320px !important;
    }}
}}
@media only screen and (min-device-width: 375px) and (max-device-width: 413px) {{
    u ~ div .email-container {{
        min-width: 375px !important;
    }}
}}
@media only screen and (min-device-width: 414px) {{
    u ~ div .email-container {{
        min-width: 414px !important;
    }}
}}
.primary{{
	background: #30e3ca;
}}
.bg_white{{
	background: #ffffff;
}}
.bg_light{{
	background: #fafafa;
}}
.bg_black{{
	background: #000000;
}}
.bg_dark{{
	background: rgba(0,0,0,.8);
}}
.email-section{{
	padding:2.5em;
}}

/*BUTTON*/
.btn{{
	padding: 10px 15px;
	display: inline-block;
}}
.btn.btn-primary{{
	border-radius: 5px;
	background: #30e3ca;
	color: #ffffff;
}}
.btn.btn-secondry{{
	border-radius: 5px;
	background: #F88930;
	color: #ffffff;
}}
.btn.btn-white{{
	border-radius: 5px;
	background: #ffffff;
	color: #000000;
}}
.btn.btn-white-outline{{
	border-radius: 5px;
	background: transparent;
	border: 1px solid #fff;
	color: #fff;
}}
.btn.btn-black-outline{{
	border-radius: 0px;
	background: transparent;
	border: 2px solid #000;
	color: #000;
	font-weight: 700;
}}

h1,h2,h3,h4,h5,h6{{
	font-family: 'Cairo', sans-serif;
	color: #000000;
	margin-top: 0;
	font-weight: 400;
}}
body{{
	font-family: 'Cairo', sans-serif;
	font-weight: 400;
	font-size: 16px;
	line-height: 1.8;
	color: rgba(0,0,0,.4);
}}
a{{
	color: #2365B2;
}}
/*LOGO*/
.logo h1{{
	margin: 0;
}}
.logo h1 a{{
	color: #2365B2;
	font-size: 1.5rem;
	font-weight: 700;
	font-family: 'Cairo', sans-serif;
}}
/*HERO*/
.hero{{
	position: relative;
	z-index: 0;
	 background-image: url('{ApiUrl}/TemplateEmail/bg_pattern.png');
	 background-position: bottom center;
    background-size: cover;
}}
.hero .text{{
	color: #0d6c71;
font-weight:500;
}}
.hero h2,
.hero h4{{
		color: #1E999D;

}}
.hero ul li p span{{
	color: #F88930;
}}
.hero .text h2{{
	font-size: 2.5rem;
	margin-bottom: 0;
	font-weight: 400;
	line-height: 1.4;
}}
.hero .text h3{{
	font-size: 1.5rem;
	font-weight: 300;
}}
.hero .text h2 span{{
	font-weight: 600;
	color: #30e3ca;
}}
.hero ul li {{
list-style: none;
}}
/*HEADING SECTION*/
.heading-section h2{{
	color: #000000;
	font-size: 1.75rem;
	margin-top: 0;
	line-height: 1.4;
	font-weight: 400;
}}
.heading-section .subheading{{
	margin-bottom: 1.3rem !important;
	display: inline-block;
	font-size: 0.87rem;
	text-transform: uppercase;
	letter-spacing: 2px;
	color: rgba(0,0,0,.4);
	position: relative;
}}
.heading-section .subheading::after{{
	position: absolute;
	left: 0;
	right: 0;
	bottom: -10px;
	content: '';
	width: 100%;
	height: 2px;
	background: #30e3ca;
	margin: 0 auto;
}}

.heading-section-white{{
	color: rgba(255,255,255,.8);
}}
.heading-section-white h2{{
	/* font-family:  */
	line-height: 1;
	padding-bottom: 0;
}}
.heading-section-white h2{{
	color: #ffffff;
}}
.heading-section-white .subheading{{
	margin-bottom: 0;
	display: inline-block;
	font-size: 0.9rem;
	text-transform: uppercase;
	letter-spacing: 2px;
	color: rgba(255,255,255,.4);
}}
ul.social{{
	padding: 0;
}}
ul.social li{{
	display: inline-block;
	margin-right: 10px;
}}
/*FOOTER*/
.footer{{
			border-top: 1px solid rgba(0,0,0,.05);
            /* background-image: url('{ApiUrl}/TemplateEmail/bg_pattern.png'); */
            width: 71%;
            height: 20rem;
            /* background-position: top center; */
            /* background-size: cover; */
            padding: 3rem;
            padding-top: 0;
}}
.footer .heading{{
	color: #000;
	font-size: 1.2rem;
}}
.footer ul{{
	margin: 0;
	padding: 0;
}}
.footer ul li{{
	list-style: none;
	margin-bottom: 10px;
}}
.footer ul li a{{
	color: rgba(0,0,0,1);
}}
th span{{
	color: #F88930;
	font-size: 13px;
}}
.links a{{
	margin-left: 10px;
	color: #1E999D;
}}

@media screen and (max-width: 900px) {{
	.massage-img{{
		top: 100px !important;
		left: 20px !important;
	}}
	.main-table{{
		width: 100% !important;
		}}
		.hero{{
			padding: 0 15px !important;
		}}
		}}
		@media screen and (max-width: 700px) {{
			.massage-img{{
				top: 100px !important;
				left: 50px !important;
			}}
			
			
			
		}}
		@media screen and (max-width: 500px) {{
			.massage-img{{
				top: 90px !important;
				left: 20px !important;
			}}
			.footer-text{{
				width: 100%!important;
			}}
				}}
		
    </style>
</head>

<body width=""100%"" style=""margin: 0; padding: 0 !important; mso-line-height-rule: exactly; "">
	<center style=""width: 100%; background-color: #f1fafb;"">
    
    <div style="" margin: 0 auto;"" class=""email-container"">
    	<!-- BEGIN BODY -->
      <table class=""main-table"" align=""center"" role=""presentation"" cellspacing=""0"" cellpadding=""0"" border=""0"" width=""70%"" style=""margin: auto;"">
        
      	<tr>
          <td valign=""top"" class=""bg_white"" style=""padding: 1em 2.5em 0 2.5em;"">
          	<table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
          		<tr>
          			<td class=""logo"" style=""text-align: center;"">
			            <h1><a href=""#""><img src=""{ApiUrl}/TemplateEmail/waqfiLogo.png"" alt="""" srcset=""""></a></h1>
			          </td>
          		</tr>
          	</table>
          </td>
	      </tr><!-- end tr -->
	    
		<tr>
        	<td valign=""middle"" class=""hero bg_white"" style=""padding: 0 5rem 9em 9rem; margin-inline: 5rem;"">
            <table>
            	<tr>
            		<td >
            			<div class=""text"" style="" text-align: right;"">
            				<h2 style=""font-size: 24px;"">السلام عليكم</h2>
            				<p>تم استلام رسالة جديدة من تواصل معنا</p>
            			</div>
            		</td>
            	</tr>
            </table>
			<p>تفاصيل الرسالة :</p>
			<table style="" text-align: right;  position: relative; display: inline-block; width:100%;"">
<tbody>
<tr>
<td></td>
<td style=""width:100%; ""><span class=""massage-img"" style=""width:100%; text-align: left;display: inline-block;"">
						<img src=""{ApiUrl}/TemplateEmail/mail_icn_combined.png"" alt="""" srcset="""">
					</span></td>

</tr>
</tbody>
					
				<tbody style=""background-color: #ffffff !important; border: 1px solid #DEDEDE; border-radius: 10px !important;"" >


					<tr style=""padding-inline: 10px;"">
						<th style=""width: 20%; padding-right: 10px;white-space: nowrap;""><span  style=""margin-right: 10px;"">الإسم كاملاً</span> </th>
						<td><p>: {Name}</p</td>
						</tr>
						<tr>
							<th style=""width: 20%; padding-right: 10px;white-space: nowrap;""><span style=""margin-right: 10px;"">البريد الإلكتروني </span> </th>
							<td><p> : {Email}</p></td>
						</tr>
						<tr>
							<th style=""width: 20%; padding-right: 10px;white-space: nowrap;""><span style=""margin-right: 10px;"">رقم الجوال </span> </th>
							<td><p> : {Mobile}</p></td>
						</tr>
						<tr>
							<th valign=""top"" style=""width: 20%; padding-right: 10px;white-space: nowrap;""><span  style="" margin-right: 10px;"">موضوع الرسالة</span> </th>
							<td ><p style=""margin-top: 0px;"">
								<strong>: {SubjectMessage}</strong>
								<br> 
								<br> 
                                        {BodyMessage}
								</p>
							</td>
						</tr>
						<tr >
							<th></th>
							<td style=""text-align: end;"">
								<p style=""margin-left: 15px;"">
									وشكرا لكم في انتظار ردكم
								</p>
							</td>
						</tr>
					</tbody>
					</table>

			</td>
		</tr>
	</table>
<table class=""footer-text"" >
	   <tr>
	   <p style=""margin-top:1px; background-color: #FFFFFF !important; padding: 5px 0 5px 0; text-align: center; width: 100%;"">©جميع الحقوق محفوظة 2023</p>
	 </tr>
   </table>


     

    </div>
  </center>
</body>
</html>
";

    }
}
