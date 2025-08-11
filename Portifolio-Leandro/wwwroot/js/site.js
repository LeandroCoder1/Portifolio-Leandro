let particles = [];

function setup() {
    const canvas = createCanvas(windowWidth, windowHeight);
    canvas.parent('bg-canvas');
    for (let i = 0; i < 120; i++) particles.push(new Particle());
    noStroke();
}

function windowResized() {
    resizeCanvas(windowWidth, windowHeight);
}

function draw() {
    clear();
    for (let p of particles) {
        p.update();
        p.draw();
    }
}

class Particle {
    constructor() {
        this.pos = createVector(random(width), random(height));
        this.vel = p5.Vector.random2D().mult(random(0.1, 0.8));
        this.size = random(1, 4);
        this.col = color(0, 255, 210, 80);
    }
    update() {
        let mouse = createVector(mouseX, mouseY);
        let dir = p5.Vector.sub(mouse, this.pos);
        let d = dir.mag();
        if (d < 150) {
            dir.setMag((150 - d) * 0.0008);
            this.vel.add(dir);
        }
        this.pos.add(this.vel);
        if (this.pos.x < -50) this.pos.x = width + 50;
        if (this.pos.x > width + 50) this.pos.x = -50;
        if (this.pos.y < -50) this.pos.y = height + 50;
        if (this.pos.y > height + 50) this.pos.y = -50;
        this.vel.mult(0.995);
    }
    draw() {
        fill(this.col);
        circle(this.pos.x, this.pos.y, this.size);
    }
}

function showSection(id) {
    const targetSection = document.getElementById(id);

    // Se a seção clicada já está ativa, remove o "active" (fecha)
    if (targetSection.classList.contains("active")) {
        targetSection.classList.remove("active");
    } else {
        // Fecha todas
        sections.forEach(section => section.classList.remove("active"));
        // Abre a clicada
        targetSection.classList.add("active");
    }
}
