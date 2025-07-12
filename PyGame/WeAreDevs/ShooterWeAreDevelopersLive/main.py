import pygame
import sys
from player import Player
from enemy import Enemy

WIDTH, HEIGHT = 800, 800
FPS = 60

def main():
    pygame.init()
    screen = pygame.display.set_mode((HEIGHT, WIDTH))
    pygame.display.set_caption("Space Debugger – WeAreDevelopers")
    clock = pygame.ime.Clock()

    ## sprite groups
    players = pygame.sprite.Group()
    bullets = pygame.sprite.Group()
    enemies = pygame.sprite.Group()

    ## player
    player = Player((WIDTH / 2, HEIGHT - 8))
    players.add(player)

    ## enemy spawn
    SPAWN = pygame.USEREVENT + 1
    pygame.time.set_timer(SPAWN, 1000)

    score = 0

    running = True
    while running:
        dt = clock.tick(FPS)
        now = pygame.time.get_ticks()

        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                running = False

            ## spawn event type
            elif event.type == SPAWN:
                bug = Enemy()
                enemies.add(bug)

        keys = pygame.key.get_pressed()

        # player key
        if keys[pygame.K_SPACE]:
            player.shoot(now, bullets)

        # updates
        player.update(keys)
        bullets.update()
        enemies.update()

        # hits
        hits = pygame.sprite.groupcollide(enemies, bullets, True, True)

        score += len(hits) * 10
        font = pygame.font.Font(None, 48)
        text = font.render(f"Score: {score}", True, (0, 0, 0))

        screen.fill((255, 255, 255))
        screen.blit(text, (10, 10))

        #draw
        players.draw(screen)
        bullets.draw(screen)

        pygame.display.flip()

    pygame.quit()
    sys.exit()

if __name__ == "__main__":
    main()