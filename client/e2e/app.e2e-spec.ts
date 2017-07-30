import { OverReactionPage } from './app.po';

describe('over-reaction App', () => {
  let page: OverReactionPage;

  beforeEach(() => {
    page = new OverReactionPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
