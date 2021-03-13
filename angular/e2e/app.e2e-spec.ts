import { MovieRatingTemplatePage } from './app.po';

describe('MovieRating App', function() {
  let page: MovieRatingTemplatePage;

  beforeEach(() => {
    page = new MovieRatingTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
