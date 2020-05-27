function $(id) {
    return document.getElementById(id);
}
var code;

function createCode() {
    code = "";
    var codeLength = 4;
    var checkCode = document.getElementById("code");
    var random = new Array(2, 3, 4, 5, 6, 7, 8, 9, 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z');
    for (var i = 0; i < codeLength; i++) {
        var index = Math.floor(Math.random() * 31);
        code += random[index];
    }
    checkCode.value = code;

    $("username").onblur = function () {
        var usertext = this.value;
        if (usertext.length < 0 || usertext.length > 8) {
            $('empWorning').style.display = "block";
        }
        else {
            $('empWorning').style.display = "none";
        }
    }
}
function Button1_Click() {
    var password = $("password").value;
    var password1 = $("password1").value;
    if (password != password1) {
        alert("密码前后不同！");
        return false;
    }
    else if (password.length < 3) {
        alert("密码至少为3位！");
        return false;
    }
    var inputCode = document.getElementById("input").value.toUpperCase();
    if (inputCode.length <= 0) {
        alert("请输入验证码！");
    }
    else if (inputCode != code) {
        alert("验证码输入错误！请重新输入");
        createCode();
        document.getElementById("input").value = "";
    }
    else {
        return true;
    }
} 