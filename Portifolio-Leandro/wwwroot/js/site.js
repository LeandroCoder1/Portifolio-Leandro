document.addEventListener('DOMContentLoaded', () => {
    const sections = Array.from(document.querySelectorAll('.tab-section'));
    const navButtons = Array.from(document.querySelectorAll('.nav-btns .btn'));

    // função encapsulada que vê 'sections' corretamente
    function showSection(id) {
        console.log('showSection chamado com:', id);
        const targetSection = document.getElementById(id);
        if (!targetSection) {
            console.warn(`Seção com id="${id}" não encontrada.`);
            return;
        }

        if (targetSection.classList.contains('active')) {
            targetSection.classList.remove('active');
        } else {
            sections.forEach(s => s.classList.remove('active'));
            targetSection.classList.add('active');
        }

        // opcional: atualiza o hash sem scroll (melhora UX)
        history.replaceState(null, '', `#${id}`);
    }

    // ligar os botões (intercepta o href="#id")
    navButtons.forEach(btn => {
        btn.addEventListener('click', (e) => {
            const href = btn.getAttribute('href') || btn.dataset.target;
            if (href && href.startsWith('#')) {
                e.preventDefault();               // evita rolagem automática
                const id = href.slice(1);         // remove '#'
                showSection(id);
            } else if (btn.dataset.target) {
                e.preventDefault();
                showSection(btn.dataset.target);
            }
        });
    });

    // mostrar seção inicial (hash ou primeiro)
    const initial = location.hash ? location.hash.slice(1) : (sections[0] && sections[0].id);
    if (initial) showSection(initial);
});
