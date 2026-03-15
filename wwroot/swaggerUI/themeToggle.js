// Create a button in top-left corner
const btn = document.createElement('button');
btn.innerText = 'Toggle Dark/Light';
btn.style.position = 'fixed';
btn.style.top = '10px';
btn.style.left = '10px';
btn.style.zIndex = 1000;
btn.style.padding = '6px 12px';
btn.style.backgroundColor = '#61dafb';
btn.style.border = 'none';
btn.style.borderRadius = '4px';
btn.style.cursor = 'pointer';
document.body.appendChild(btn);

// Track current theme
let darkMode = false;
btn.addEventListener('click', () => {
    darkMode = !darkMode;
    const link = document.querySelector("link[href*='minimal-light.css'], link[href*='minimal-dark.css']");
    if (link) {
        link.href = darkMode ? '/swagger-ui/minimal-dark.css' : '/swagger-ui/minimal-light.css';
    }
});