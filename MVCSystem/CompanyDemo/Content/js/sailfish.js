/*from tccdn minify at 2017-7-24 14:07:15,file：/cn/public/jquery/sailfish/main/0.0.1/sailfish.js*/
!function(g,h,i,j){var k=h.getElementById("sfMainFrame"),l=h.getElementById("sfPageTab");return l?void i(g,h,null,!1):null===k&&g===g.top?(i(g,h,k,!0),void j(g,h)):void (k?i(g,h,k):j(g,h))}(window,document,function(k,l,m,n){function o(g,h,j){if("string"==typeof g){g=g.trim();var u=g,v=t.$sfPageTab,w=$("#sfIframeWrap");if(g.indexOf("?")>-1&&(g=g.split("?")[0]),j===!0&&g&&(sfPageTabObj[g]=u),sfPageTabObj[g]){if(sfPageTabObj[g]!=u){var x=$('.sf-tframe[src="'+sfPageTabObj[g]+'"]'),y=x.attr("src",u).addClass("sf-tframe-active").siblings().removeClass("sf-tframe-active").end().index();v.find("li").eq(y).addClass("sf-active").siblings().removeClass("sf-active").end().find("span").text(h),sfPageTabObj[g]=u}else{if(sfPageTabObj[g]===u){var y=$('.sf-tframe[src="'+sfPageTabObj[g]+'"]').addClass("sf-tframe-active").siblings().removeClass("sf-tframe-active").end().index(),z=v.find("li").eq(y).addClass("sf-active").siblings().removeClass("sf-active").end();j||z.find("span").text(h)}}}else{v.find("li").removeClass("sf-active").end().append('<li class="sf-active"><span>'+h+'</span> <i class="sf-close-sm"></i></li>'),w.find(".sf-tframe").removeClass("sf-tframe-active").end().append('<iframe src="'+u+'" class="sf-tframe sf-tframe-active"></iframe>'),sfPageTabObj[g]=u}r(),q(g)}}function p(g,j){if(!j){return void (sfPageTabObj[g]=!1)}if(0!==j.length){var u=j.index(),v=$("#sfIframeWrap").find(".sf-tframe").eq(u);"string"!=typeof g&&(g=v.attr("src").trim()),g.indexOf("?")>-1&&(g=g.split("?")[0]),sfPageTabObj[g]=!1;var w=t.$sfPageTab.find(".sf-active").not(j),x=w.length,y=null,z=null,A=null;if(0===x){if(y=j.next(),z=j.prev(),A=y.length>0?y:z.length>0?z:null){u=A.addClass("sf-active").index();var B=$("#sfIframeWrap").find(".sf-tframe").eq(u).addClass("sf-tframe-active").attr("src");q(B)}else{$("#sfMenu").find(".active").removeClass("active")}}j.remove(),v.remove()}}function q(j){j="string"==typeof j?j:"";var u=$("a",t.sfMenu),v=null;j.indexOf("?")>-1&&(j=j.split("?")[0]),$(".active",t.sfMenu).removeClass("active");for(var w=0,x=u.length;x>w;w++){var y=u[w],z=y.getAttribute("href")||"";if(z.indexOf("?")>-1&&(z=z.split("?")[0]),z===j){$(y).addClass("active"),v=y;break}}if(v){var A=$(v),B=A.parents("ul").not(t.sfMenu),C=B.size();if(C>0){if(t.$leftBar.hasClass("sf-narrow-left")){var D=B.eq(C-1).prev();D.addClass("active sf-sub-open")}else{B.slideDown(200)}}}}function r(){var i=t.$sfMtab,j=i.find(".sf-active"),u=j.position().left,v=j.outerWidth(),w=i.scrollLeft(),x=i.width(),y=u+v-(x+w),z=0;y>0?z=w+y+10:w>u&&(z=u-10),i.animate({scrollLeft:z},200)}function s(b){t.$sfPageTab.find(".sf-active span").text(b)}var t={sfMenu:l.getElementById("sfMenu"),sfMainFrame:m,sfPageTab:l.getElementById("sfPageTab"),$sfPageTab:$(this.sfPageTab),$sfMtab:$("#sfMtab"),$leftBar:$(".sf-left-bar"),init:function(){this.checkSfCache(),this.sfMainFrame&&this.linkFixed(this.sfMainFrame),this.sfPageTab&&(this.menuFixed(),o($("#sfIframeWrap").find(".sf-tframe-active").attr("src"),"",!0)),this.eventInit()},eventInit:function(){var c=this;$("a",c.sfMenu).on("click",function(a){var g=$(this),h=g.next("ul"),i=this.href||"";if(h[0]&&!c.$leftBar.hasClass("sf-narrow-left")){var j=$(".sf-menu-arrow",this);if(0!=i.indexOf("#")&&0!=i.indexOf("javascript:")&&!g.hasClass("active")&&"none"!==h.css("display")){return}"none"===h.css("display")?(j.removeClass("fa-angle-down").addClass("fa-angle-up"),h.slideDown(200),g.addClass("sf-sub-open")):(j.removeClass("fa-angle-up").addClass("fa-angle-down"),h.slideUp(200),g.removeClass("sf-sub-open"))}}),$("#scaleBtn").on("click",function(){if(c.$leftBar.hasClass("sf-narrow-left")){$(".active",c.sfMenu).parents("ul").prev().removeClass("active");var a=$(".active",c.sfMenu);a[0]&&a.parents("ul").not(c.sfMenu).slideDown(200)}else{var a=$(".active",c.sfMenu);if(a[0]){var e=a.parents("#sfMenu > li");$("a",e).eq(0).addClass("active")}$("ul",c.sfMenu).slideUp(10),$(".sf-menu-arrow",c.sfMenu).removeClass("fa-angle-up").addClass("fa-angle-down")}c.$leftBar.toggleClass("sf-narrow-left")}),$("#sfSkinWrap").on("click","span",function(){var a=$(this);if(!a.hasClass("cur")){var e=a.data("skin");c.updateSkin(e),a.addClass("cur").siblings().removeClass("cur"),localStorage.setItem("sfCacheSkin",e)}}),$("#sfLayoutBtn").on("click",function(){var a=this.checked;c.updateLayout(a),localStorage.setItem("sfCacheLayout",a)});var d=$("#sfRefresh");d.length&&(this.sfMainFrame?d.on("click",function(){c.sfMainFrame.src=c.sfMainFrame.src}):this.sfPageTab?d.on("click",function(){var b=$("#sfIframeWrap").find(".sf-tframe-active");b.attr("src",b.attr("src"))}):d.on("click",function(){location.reload()})),this.sfPageTab&&(this.$sfPageTab.on("click","li",function(){var e=$(this);if(!e.hasClass("sf-active")){e.addClass("sf-active").siblings().removeClass("sf-active");var f=e.index(),g=$("#sfIframeWrap").find(".sf-tframe").eq(f).addClass("sf-tframe-active").siblings().removeClass("sf-tframe-active").end().attr("src");q(g)}}).on("click",".sf-close-sm",function(b){b.stopPropagation(),p(void 0,$(this).parent())}).parents(".sf-multi-tab").on("click",".move-btn",function(){var a=$(this),f=c.$sfMtab,g=f.scrollLeft(),h=200;a.hasClass("fa-angle-left")&&(h=-200),f.animate({scrollLeft:g+h},200)}),$("#sfPageTabHandler").on("click","li",function(a){var e=$(this);e.hasClass("sf-close-other")?c.$sfPageTab.find("li").each(function(){var b=$(this);b.hasClass("sf-active")||p(void 0,$(this))}):e.hasClass("sf-close-active")?p(void 0,c.$sfPageTab.find(".sf-active")):e.hasClass("sf-find-active")&&c.$sfPageTab.find(".sf-active").length&&r()}))},linkFixed:function(b){$(l).on("click","a",function(a){var f=$(this),g=this.href,h=this.target;"_blank"!==h&&g&&"#"!==g&&0!==g.indexOf("#")&&0!==g.indexOf("javascript:")&&(f.hasClass("active")||b&&(b.src=g),a.preventDefault())})},menuFixed:function(){$("a",this.sfMenu).on("click",function(e){var g=$(this),h=g.attr("href")||"",i=g.find("span").eq(0).text()||this.text,j=this.target;return g.hasClass("active")?void e.preventDefault():void ("_blank"!==j&&h&&"#"!==h&&0!==h.indexOf("#")&&0!==h.indexOf("javascript:")&&(e.preventDefault(),o(h,i)))})},updateSkin:function(e){var f={"default":"sf-theme-blue sf-theme-orange",blue:"sf-theme-default sf-theme-orange",orange:"sf-theme-default sf-theme-blue"};e=e||$("#sfSkinWrap").find(".cur").data("skin");var g=f[e];if(g&&($("body").addClass("sf-theme-"+e).removeClass(f[e]),this.sfMainFrame)){var h=this.sfMainFrame.contentWindow.document.body;h&&$(h).addClass("sf-theme-"+e).removeClass(f[e])}},updateLayout:function(c,d){$("body").toggleClass("sf-plumb",c),d&&(d.checked=c)},checkSfCache:function(){var b=localStorage.getItem("sfCacheSkin")||$("#sfSkinWrap").find(".cur").data("skin"),d=localStorage.getItem("sfCacheLayout");d&&this.updateLayout(!!d.replace("false",""),l.getElementById("sfLayoutBtn")),b&&(this.updateSkin(b),$("#sfSkinWrap").find("span").removeClass("cur").end().find(".sf-skin-"+b).addClass("cur"))},sfUpdateMenuState:function(){if(this.sfMainFrame||n){var a=this.sfMainFrame&&this.sfMainFrame.src||location.href,b=$("a",this.sfMenu),d=null,x="",y=[],z=l.getElementById("sfCrumb");a.indexOf("?")>-1&&(a=a.split("?")[0]),$(".active",this.sfMenu).removeClass("active");for(var A=0,B=b.length;B>A;A++){var C=b[A],D=C.href;if(D.indexOf("?")>-1&&(D=D.split("?")[0]),D===a){$(C).addClass("active"),d=C;break}}if(z){if(d){var E=$(d),F=E.parents("ul").not(this.sfMenu),G=F.size();if(G>0){if(this.$leftBar.hasClass("sf-narrow-left")){var H=F.eq(G-1).prev();H.addClass("active sf-sub-open")}else{F.slideDown(200);for(var I=0;G>I;I++){var J=$(F[I]).prev(),K={text:J.find("span").text(),link:J.attr("href")};y.push(K)}}}y.unshift({text:E.find("span").text(),link:E.attr("href")}),y.reverse()}else{y=k.configCrumb||this.sfMainFrame&&this.sfMainFrame.contentWindow.configCrumb||[]}for(var L=0,M=y.length;M>L;L++){var N=y[L],D=N.link;(""===D||void 0===D)&&(D="javascript:;"),x+=L===M-1?"<li>"+N.text+"</li>":"#"!==D&&0!==D.indexOf("#")&&0!==D.indexOf("javascript:")?'<li><a href="'+D+'">'+N.text+"</a></li>":"<li>"+N.text+"</li>"}z.innerHTML=x}}}};k.sfPageTabObj={},t.init(),k.sailFishMain=t,k.openSfPage=o,k.updateSfPageMenu=q,k.closeSfPage=p,k.updateSfTabTxt=s},function(c,d){$(function(){"object"==typeof c.top.sailFishMain&&("function"==typeof c.top.sailFishMain.sfUpdateMenuState&&c.top.sailFishMain.sfUpdateMenuState(),"function"==typeof c.top.sailFishMain.checkSfCache&&c.top.sailFishMain.checkSfCache());var a={init:function(){this.eventInit()},eventInit:function(){var b=c.top.document,q=b.getElementById("sfMainFrame"),r=b.getElementById("sfPageTab"),s=this;q&&$(d).on("click","a",function(e){var f=this.href,g=this.target;"_blank"!==g&&f&&"#"!==f&&0!==f.indexOf("#")&&0!==f.indexOf("javascript:")&&(q.src=f,e.preventDefault())}),r&&$(d).on("click","a",function(f){var g=this.getAttribute("href")||"",h=this.target,i=this.title||this.innerText.trim(),j=this.getAttribute("data-target")||"";"_blank"!==h&&g&&"#"!==g&&0!==g.indexOf("#")&&0!==g.indexOf("javascript:")&&("_blank"===j?openSfPage(g,i):copenSfPage(g,i),f.preventDefault())});var t=$(".sf-condition");if(t.length){this.conditionToggle(t),$(".sf-condition").on("click",".toggle-btn",function(){var e=$(this),f=e.parents(".sf-condition").find(".sf-condition-cont"),g=$("li",f).eq(0).outerHeight(),h=f.height();g===h?(e.html("收起"),f.height("auto")):(e.html("展开"),f.height(g))});var u=null;$(c).resize(function(){u&&clearTimeout(u),u=setTimeout(function(){s.conditionToggle()},200)})}var v=$(".sf-panel");v.length&&v.on("click",".sf-panel-toggle",function(){var e=$(this),f=e.parents(".sf-panel").find(".sf-panel-body");e.toggleClass("fa-angle-down"),f.slideToggle(200)});var w=$(".sf-select2");w.length&&w.select2({}),$(".sf-floating-click").length&&$("body").on("click",".sf-floating-click > span",function(e){e.stopPropagation();var f=$(this),g=f.next(),h=g.css("display");f.length&&g.length&&($(".sf-floating-click .sf-floating-cont").hide(),"none"===h?g.show():g.hide())}).on("click",function(e){var f=$(e.target),g=f.closest(".sf-floating-cont");g.length||$(".sf-floating-click .sf-floating-cont").hide()});var x=$(".sf-tab-wrap");x.length&&x.mTab({tab:"ul li",content:".sf-tab-item",append:"sf-cur",none:"none",init:function(){},fn:function(e,f){}});var y=d.getElementById("sfBackTop");if(y){var z=200,A=100,B=function(e){e=e||"none",y.style.display=e};y.onclick=function(){$("body").animate({scrollTop:0},200,B)};var C=null;$(c).on("scroll",function(){C&&clearTimeout(C),C=setTimeout(function(){var e=$("body").scrollTop(),f="none";e>=A&&(f="block"),B(f)},z)})}},conditionToggle:function(b){b=b||$(".sf-condition"),b.each(function(){var j=$(".sf-condition-cont",this),k=$("li",j),l=k.eq(0),m=k.size(),n=l.width(),o=l.outerHeight(),p=j.width(),q=j.height();if(q===o){var r=$(".toggle-btn",this);n*m>p?!r[0]&&$(".sf-condition-btns",this).append('<a href="javascript:;" class="toggle-btn">展开</a>'):r[0]&&r.remove()}})}};c.openSfPage=function(e,f){"function"==typeof c.top.openSfPage&&c.top.openSfPage(e,f)},c.copenSfPage=function(g,h){var i=c.top,j=$(".sf-tframe-active",i.document),k=j.attr("src");j.attr("src",g),"function"==typeof i.closeSfPage&&i.closeSfPage(k),"function"==typeof i.updateSfPageMenu&&i.updateSfPageMenu(g),"function"==typeof i.updateSfTabTxt&&i.updateSfTabTxt(h)},a.init()}),function(){function b(g){var h=d.createElement("a");return h.href=g,{protocol:h.protocol,host:h.host,hostname:h.hostname,port:h.port,origin:h.origin,pathname:h.pathname,search:h.search,hash:h.hash}}function e(i,j){for(var k,l,m=i.split("&"),n=j?void 0:{},o=0,p=m.length;p>o;o++){if(k=m[o]){if(k=k.split("="),l=k.shift(),j){if(j===l){return k.join("=")}}else{n[l]=k.join("=")}}}return n}function f(){var g=function(){return(65536*(1+Math.random())|0).toString(16).substring(1)};return g()+g()+"-"+g()+"-"+g()+"-"+g()+"-"+g()+g()+g()}$.parseUrl=b,$.parseParam=e,$.createGuid=f}()});