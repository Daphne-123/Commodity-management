<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reg.aspx.cs" Inherits="Store.Reg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
			<div class="header_c">
				<h1 class="dept"><span class="crm">客户关系管理系统</span></h1>
			</div>
			<div class="header_bg"></div>
		</div>
		<div class="regFrm-Content" >
			<div class="regFrm-Main">
				<dl id="empNoD1" class="regFrm-item">
					<dt class="regFrm-item-tit"><span class="txt-impt"></span>工号</dt>
					<dd class="regFrm-item-ct">
						<div class="regFrm-item-ipt">
							<input type="text" name="empNo" id="empNo" class="ipt" autocomplete="off" />  
						</div>
						<div id="empNoTips" class="tips">
							<span class="txt-tips">6-18个字符，可使用字母、数字、下划线</span>
							<span id="empNo-tips" class="worning"> 工号必须是0-4个阿拉伯数字 </span>
						</div>
					</dd>
				</dl>
				<dl class="regFrm-item" id="pwdDl">
					<dt class="regFrm-item-tit"><span class="txt-impt"></span>密码</dt>
					<dd class="regFrm-item-ct">
						<div class="regFrm-item-ipt">
							<input type="password" name="pwd" id="pwd" class="ipt" autocomplete="off" /> 
						</div>
						<div id="pwdTips" class="tips">
							<span class="txt-tips">6-16个字符，区分大小写</span>
						</div>
					</dd>
				</dl>
				<dl id="cfmPwdDl" class="regFrm-item">
					<dt class="regFrm-item-tit"><span class="txt-impt">*</span>确认密码</dt>
					<dd class="regFrm-item-ct">
						<div class="regFrm-item-ipt">
							<input type="password" name="cfmpwd" id="cfmpwd" class="ipt" autocomplete="off"> 
						</div>
						<div id="cfmpwdTips" class="tips">
							<span class="txt-tips">请再次填写密码</span>
						</div>
					</dd>
				</dl>
				<dl id="vCodeDl" class="regFrm-item">
					<dt class="regFrm-item-tit"><span class="txt-impt">*</span>验证码</dt>
					<dd class="regFrm-item-ct">
						<div class="regFrm-item-ipt">
							<input type="text" name="vcode" id="vCode" class="ipt" autocomplete="off"><img src="#" id="imgVCode" class="vCode-img" />
						</div>
						<div id="userNameTips" class="tips">
							<span class="txt-tips">请填写图片中的验证码，不区分大小写</span>
                            <span id="codeWorning" class="worning vCode-tips"><%=codeWrong %></span>
						</div>
					</dd>
				</dl>
				<dl id="btnRegDl" class="regFrm-item">
					<input type="submit" id="btnReg" class="ipt btn" value="注册">
				</dl>
			</div>
			<div class="regFrm-side">
				
			</div>
		</div>
		<div class="footer">版权所有，解释权归胡少航所有</div>
    </form>
</body>
</html>
