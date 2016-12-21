$(function () {
    var fr = new FileReader();
    $("#file").on("change", function () {
        var files = $("#file")[0].files;
        if (FileReader && files && files.length) {
            fr.readAsArrayBuffer(files[0]);
            console.log(files);
            console.log(files[0]);
            fr.onload = function () {
                var base64 = '';
                var base64WithPrefix = '';
                console.log(fr.result);
                var imageData = new Uint8Array(fr.result);
                base64 = btoa(Uint8ToString(imageData));

                base64WithPrefix = "data:image/jpeg;base64," + base64
                //alert(binary);
                $("#imgBase64").prop("src", base64WithPrefix)
                $("#ImageBase64").val(base64);
                $("#ImageName").val(files[0].name);
            };
        }
    });

    function Uint8ToString(u8a) {
        var CHUNK_SZ = 0x8000;
        var c = [];
        for (var i = 0; i < u8a.length; i += CHUNK_SZ) {
            c.push(String.fromCharCode.apply(null, u8a.subarray(i, i + CHUNK_SZ)));
        }
        return c.join("");
    }
});