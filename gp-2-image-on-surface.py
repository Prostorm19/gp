import pygame 

pygame.init()

screen = pygame.display.set_mode((400,500))
done = False
while not done:
    for event in pygame.event.get():
        if event.type==pygame.QUIT:
            done=True
    pygame.display.flip()

import pygame
pygame.init()
white = (255, 255, 255)
height = 700
width = 700
display_surface = pygame.display.set_mode((height, width))
pygame.display.set_caption("Image")
image = pygame.image.load(r"911 turbo.jpg")
image = pygame.transform.scale(image, (width, height))
running = True
while running:
    display_surface.fill(white)

    display_surface.blit(image, (0, 0))

    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False

    pygame.display.update()

pygame.quit()