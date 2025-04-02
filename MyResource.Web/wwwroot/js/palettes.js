window.currentPaletteId = null;

window.initPalettePage = function () {
    const colorInputs = document.querySelectorAll(".color input[type='color']");
    colorInputs.forEach(input => {
        input.addEventListener("input", () => {
            const textInput = input.nextElementSibling;
            textInput.value = input.value;
            applyPalette();
        });
    });

    const textInputs = document.querySelectorAll(".color input[type='text']");
    textInputs.forEach(input => {
        input.addEventListener("input", () => {
            const colorInput = input.previousElementSibling;
            colorInput.value = input.value;
            applyPalette();
        });
    });

    const copyBtn = document.getElementById("copyBtn");
    if (copyBtn) copyBtn.addEventListener("click", copyPalette);

    applyPalette();
};

window.resetPalette = function () {
    const defaults = {
        base: "#1e1e1e",
        section: "#2a2a2a",
        text: "#ffffff",
        secondaryText: "#b0b0b0",
        accent: "#4aa3df",
        line: "#474747",
        hover: "#333333",
        shadow: "#d0d0d0"
    };

    for (const [id, value] of Object.entries(defaults)) {
        window.setColorValue(id, value);
    }

    applyPalette();
};

function applyPalette() {
    const inputs = document.querySelectorAll(".color input[type='text']");
    inputs.forEach(input => {
        const cssVar = input.getAttribute("color-var");
        document.documentElement.style.setProperty(cssVar, input.value);
    });
}

function copyPalette() {
    const inputs = document.querySelectorAll(".color input[type='text']");
    const colors = Array.from(inputs).map(input => input.value).join(", ");
    navigator.clipboard.writeText(colors);
    alert("Copied: " + colors);
}

window.getColorValue = function (id) {
    return document.getElementById(id)?.value ?? "";
};

window.setColorValue = function (id, value) {
    const input = document.getElementById(id);
    if (input) {
        input.value = value;
        const textInput = input.type === "color" ? input.nextElementSibling : input.previousElementSibling;
        if (textInput) textInput.value = value;
    }
};