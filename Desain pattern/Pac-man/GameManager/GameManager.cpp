#include <GL/glut.h>
#include "GameManager.h"
#include "Pacman.h"
#include "GhostHandler.h"
#include "Map.h"

void setupGame() {
    findPacman();
    findGhosts();
    glutTimerFunc(200, timer, 0);
}

void timer(int value) {
    for (int i = 0; i < ghostCount; i++) {
        moveGhost(ghosts[i]);
    }

    glutPostRedisplay(); // Refresh display
    glutTimerFunc(200, timer, 0); // Loop
}

void keyboard(int key, int x, int y) {
    switch (key) {
        case GLUT_KEY_UP:    movePacman(0, -1); break;
        case GLUT_KEY_DOWN:  movePacman(0, 1); break;
        case GLUT_KEY_LEFT:  movePacman(-1, 0); break;
        case GLUT_KEY_RIGHT: movePacman(1, 0); break;
    }
}
