$(function () {
    var fr = new FileReader();
    $("#file").on("change", function () {
        var files = $("#file")[0].files;
        if (FileReader && files && files.length) {
            fr.readAsArrayBuffer(files[0]);
            console.log(fr.result);
            fr.onload = function () {
                var binary = '';
                console.log(fr.result);
                var imageData = new Uint8Array(fr.result);
                binary = btoa(Uint8ToString(imageData));

                binary = "data:image/jpeg;base64," + binary
                alert(binary);
                $("#imgBase64").prop("src", binary)
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