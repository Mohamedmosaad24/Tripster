
    document.getElementById("sortForm")
    .querySelector("select")
    .addEventListener("change", function () {
        document.getElementById("sortForm").submit();
        });

const navLinks = document.querySelectorAll('.nav-link');
const sections = document.querySelectorAll('section');
const navbar = document.getElementById('navbar');

// Function to remove active class from all links
function removeActiveClasses() {
    navLinks.forEach(link => link.classList.remove('active'));
}

// Function to add active class to a specific link
function setActiveLink(id) {
    removeActiveClasses();
    const activeLink = document.querySelector(`.nav-link[href="#${id}"]`);
    if (activeLink) {
        activeLink.classList.add('active');
    }
}

// Click event for scrolling and immediate active state
navLinks.forEach(link => {
    link.addEventListener('click', (e) => {
        e.preventDefault();
        const targetId = link.getAttribute('href').substring(1);
        const targetSection = document.getElementById(targetId);

        setActiveLink(targetId);

        targetSection.scrollIntoView({
            behavior: 'smooth',
            block: 'start'
        });
    });
});

let scrollTimeout;
window.addEventListener('scroll', () => {
    // Add scrolled class to navbar
    if (window.scrollY > 50) {
        navbar.classList.add('scrolled');
    } else {
        navbar.classList.remove('scrolled');
    }

    // Debounce scroll event for performance
    clearTimeout(scrollTimeout);
    scrollTimeout = setTimeout(() => {
        let current = '';

        sections.forEach(section => {
            const sectionTop = section.offsetTop;
            const sectionHeight = section.clientHeight;

            if (window.scrollY >= sectionTop - 100) {
                current = section.getAttribute('id');
            }
        });
        if (current) {
            setActiveLink(current);
        }
    }, 50);
});

window.addEventListener('load', () => {
    let current = '';
    sections.forEach(section => {
        const sectionTop = section.offsetTop;
        if (window.scrollY >= sectionTop - 100) {
            current = section.getAttribute('id');
        }
    });
    if (current) {
        setActiveLink(current);
    }
});